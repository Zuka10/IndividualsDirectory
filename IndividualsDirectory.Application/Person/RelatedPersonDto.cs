using IndividualsDirectory.Domain.Enums;

namespace IndividualsDirectory.Application.Person;

public class RelatedPersonDto
{
    public int RelatedPersonId { get; set; }
    public RelationshipType RelationshipType { get; set; }
}