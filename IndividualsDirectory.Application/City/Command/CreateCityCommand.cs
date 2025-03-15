using MediatR;

namespace IndividualsDirectory.Application.City.Command;

public class CreateCityCommand : IRequest<int>
{
    public string Name { get; set; } = null!;
}