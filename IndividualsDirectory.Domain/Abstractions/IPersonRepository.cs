using IndividualsDirectory.Domain.Entities;
using IndividualsDirectory.Domain.Enums;

namespace IndividualsDirectory.Domain.Abstractions;

public interface IPersonRepository : IBaseRepository<Person>
{
    Task<List<Person>> SearchAsync(string searchTerm);
    Task AddRelatedIndividualAsync(int personId, int relatedPersonId, RelationshipType relationshipType);
    Task DeleteRelatedIndividualAsync(int personId, int relatedPersonId);
}