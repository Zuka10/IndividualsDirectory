using IndividualsDirectory.Domain.Enums;
using MediatR;

namespace IndividualsDirectory.Application.Person.Command.AddRelated;

public class AddRelatedPersonCommand : IRequest<bool>
{
    public int PersonId { get; set; }
    public int RelatedPersonId { get; set; }
    public RelationshipType Relationship { get; set; }
}