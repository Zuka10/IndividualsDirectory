using MediatR;

namespace IndividualsDirectory.Application.Person.Command.Delete;

public class DeletePersonCommand : IRequest<bool>
{
    public int Id { get; set; }
}