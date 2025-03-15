using MediatR;

namespace IndividualsDirectory.Application.City.Query;

public class GetAllCityQuery : IRequest<List<CityDto>> { }