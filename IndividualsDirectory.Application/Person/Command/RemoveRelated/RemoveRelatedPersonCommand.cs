using MediatR;

namespace IndividualsDirectory.Application.Person.Command.RemoveRelated;

public class RemoveRelatedPersonCommand : IRequest<bool>
{
    public int PersonId { get; set; }
    public int RelatedPersonId { get; set; }
}