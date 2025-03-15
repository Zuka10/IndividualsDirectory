using MediatR;

namespace IndividualsDirectory.Application.Person.Command.Update;

public class UpdatePersonCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PersonalNumber { get; set; } = null!;
    public DateTime BirthDate { get; set; }
}