using IndividualsDirectory.Domain.Enums;

namespace IndividualsDirectory.Domain.Report;

public class RelatedIndividualsReportModel
{
    public int PersonId { get; set; }
    public RelationshipType RelationshipType { get; set; }
    public int RelatedIndividualsCount { get; set; }
    public string PersonName { get; set; }
}