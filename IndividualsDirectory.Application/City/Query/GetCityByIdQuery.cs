using MediatR;

namespace IndividualsDirectory.Application.City.Query;

public class GetCityByIdQuery : IRequest<CityDto>
{
    public int Id { get; set; }
}