using IndividualsDirectory.Domain.Entities;
using IndividualsDirectory.Domain.Enums;
using IndividualsDirectory.Domain.Report;

namespace IndividualsDirectory.Domain.Abstractions;

public interface IPersonRepository : IBaseRepository<Person>
{
    Task<List<Person>> SearchAsync(string searchTerm, int skip, int take);
    Task AddRelatedIndividualAsync(int personId, int relatedPersonId, RelationshipType relationshipType);
    Task DeleteRelatedIndividualAsync(int personId, int relatedPersonId);
    Task<List<RelatedIndividualsReportModel>> GetRelatedIndividualsReportAsync(CancellationToken cancellationToken);
}