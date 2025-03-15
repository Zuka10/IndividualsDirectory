using AutoMapper;
using IndividualsDirectory.Domain.Abstractions;
using MediatR;

namespace IndividualsDirectory.Application.City.Query;

public class GetCityByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetCityByIdQuery, CityDto>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<CityDto> Handle(GetCityByIdQuery request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<CityDto>(await _unitOfWork.CityRepository.GetAsync(c => c.Id == request.Id, cancellationToken));
        return result;
    }
}