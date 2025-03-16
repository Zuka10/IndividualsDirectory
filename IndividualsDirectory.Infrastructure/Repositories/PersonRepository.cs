using IndividualsDirectory.Domain.Abstractions;
using IndividualsDirectory.Domain.Entities;
using IndividualsDirectory.Domain.Enums;
using IndividualsDirectory.Domain.Report;
using IndividualsDirectory.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IndividualsDirectory.Infrastructure.Repositories;

public sealed class PersonRepository(IndividualsDbContext context) : BaseRepository<Person>(context), IPersonRepository
{
    private readonly IndividualsDbContext _context = context;

    public async Task AddRelatedIndividualAsync(int personId, int relatedPersonId, RelationshipType relationshipType)
    {
        var existingRelation = await _context.RelatedIndividuals
        .FirstOrDefaultAsync(r => r.PersonId == personId && r.RelatedPersonId == relatedPersonId);

        if (existingRelation != null)
        {
            throw new RelationshipAlreadyExistsException("The relationship already exists.");
        }

        var relatedIndividual = new RelatedIndividual
        {
            PersonId = personId,
            RelatedPersonId = relatedPersonId,
            Relationship = relationshipType
        };

        await _context.RelatedIndividuals.AddAsync(relatedIndividual);
    }

    public async Task DeleteRelatedIndividualAsync(int personId, int relatedPersonId)
    {
        var relatedIndividual = await _context.RelatedIndividuals
        .FirstOrDefaultAsync(r => r.PersonId == personId && r.RelatedPersonId == relatedPersonId);

        if (relatedIndividual == null)
        {
            throw new RelationshipDoesNotExistsException("The relationship does not exist.");
        }

        _context.RelatedIndividuals.Remove(relatedIndividual);
    }

    public async Task<List<RelatedIndividualsReportModel>> GetRelatedIndividualsReportAsync(CancellationToken cancellationToken)
    {
        var report = await _context.RelatedIndividuals
            .GroupBy(r => new { r.PersonId, r.Relationship })
            .Select(g => new
            {
                g.Key.PersonId,
                g.Key.Relationship,
                RelatedIndividualsCount = g.Count()
            })
            .ToListAsync(cancellationToken);

        var result = new List<RelatedIndividualsReportModel>();

        foreach (var item in report)
        {
            var person = await _context.Persons
                .Where(p => p.Id == item.PersonId)
                .Select(p => new { p.FirstName, p.LastName })
                .FirstOrDefaultAsync(cancellationToken);

            if (person != null)
            {
                result.Add(new RelatedIndividualsReportModel
                {
                    PersonId = item.PersonId,
                    RelationshipType = item.Relationship,
                    RelatedIndividualsCount = item.RelatedIndividualsCount,
                    PersonName = $"{person.FirstName} {person.LastName}"
                });
            }
        }

        return result;
    }

    public async Task<List<Person>> SearchAsync(string searchTerm, int skip, int take)
    {
        return await _context.Persons
        .Where(p => p.FirstName.Contains(searchTerm) ||
                    p.LastName.Contains(searchTerm) ||
                    p.PersonalNumber.Contains(searchTerm))
        .Skip(skip)
        .Take(take)
        .ToListAsync();
    }
}