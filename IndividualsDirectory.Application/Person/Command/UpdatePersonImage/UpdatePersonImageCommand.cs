using MediatR;

namespace IndividualsDirectory.Application.Person.Command.UpdatePersonImage;

public class UpdatePersonImageCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string ImagePath { get; set; } = null!;
}