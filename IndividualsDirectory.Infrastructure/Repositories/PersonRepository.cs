﻿using IndividualsDirectory.Domain.Abstractions;
using IndividualsDirectory.Domain.Entities;
using IndividualsDirectory.Domain.Enums;
using IndividualsDirectory.Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace IndividualsDirectory.Infrastructure.Repositories;

public sealed class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    private readonly IndividualsDbContext _context;

    public PersonRepository(IndividualsDbContext context) : base(context)
    {
        _context = context;
    }

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
        await _context.SaveChangesAsync();
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
        await _context.SaveChangesAsync();
    }

    public async Task<List<Person>> SearchAsync(string searchTerm)
    {
        return await _context.Persons
        .Where(p => p.FirstName.Contains(searchTerm) ||
                    p.LastName.Contains(searchTerm) ||
                    p.PersonalNumber.Contains(searchTerm))
        .ToListAsync();
    }
}