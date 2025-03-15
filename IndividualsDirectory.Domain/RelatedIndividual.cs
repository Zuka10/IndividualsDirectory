using IndividualsDirectory.Domain.Enums;

namespace IndividualsDirectory.Domain;

public class RelatedIndividual
{
    public int Id { get; set; }
    public RelationshipType Relationship { get; set; }
    public int PersonId { get; set; }
    public int RelatedPersonId { get; set; }

    public virtual Person? Person { get; set; }
    public virtual Person? RelatedPerson { get; set; }
}