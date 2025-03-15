using AutoMapper;
using IndividualsDirectory.Application.City;

namespace IndividualsDirectory.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Domain.Entities.City, CityDto>();
        CreateMap<Domain.Entities.City, CityDto>().ReverseMap();
    }
}