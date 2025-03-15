using IndividualsDirectory.Domain.Abstractions;
using IndividualsDirectory.Domain.Entities;
using IndividualsDirectory.Domain.Enums;

namespace IndividualsDirectory.Infrastructure.Repositories;

public sealed class PersonRepository(IndividualsDbContext context) : BaseRepository<Person>(context), IPersonRepository
{
    public Task AddRelatedIndividualAsync(int personId, int relatedPersonId, RelationshipType relationshipType)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRelatedIndividualAsync(int personId, int relatedPersonId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Person>> SearchAsync(string searchTerm)
    {
        throw new NotImplementedException();
    }
}