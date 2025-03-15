using AutoMapper;
using IndividualsDirectory.Application.Person;
using IndividualsDirectory.Application.Person.Command.Create;
using IndividualsDirectory.Domain.Entities;

namespace IndividualsDirectory.Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreatePersonCommand, Domain.Entities.Person>()
            .ForMember(dest => dest.PhoneNumbers, opt => opt.MapFrom(src => src.PhoneNumbers))
            .ForMember(dest => dest.RelatedIndividuals, opt => opt.MapFrom(src => src.RelatedIndividuals));

        CreateMap<PhoneNumberDto, PhoneNumber>()
            .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.PhoneNumber));

        CreateMap<RelatedPersonDto, RelatedIndividual>()
            .ForMember(dest => dest.RelatedPersonId, opt => opt.MapFrom(src => src.RelatedPersonId));

        CreateMap<Domain.Entities.Person, PersonDto>()
            .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City != null ? src.City.Name : ""))
            .ForMember(dest => dest.PhoneNumbers, opt => opt.MapFrom(src => src.PhoneNumbers.Select(p => p.Number)))
            .ForMember(dest => dest.RelatedIndividuals, opt => opt.MapFrom(src => src.RelatedIndividuals.Select(r => $"{r.RelatedPerson.FirstName} {r.RelatedPerson.LastName} - {r.Relationship}")));
    }
}