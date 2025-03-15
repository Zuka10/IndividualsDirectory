using AutoMapper;
using IndividualsDirectory.Domain.Abstractions;
using MediatR;

namespace IndividualsDirectory.Application.City.Query;

public class GetAllCityQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllCityQuery, List<CityDto>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<List<CityDto>> Handle(GetAllCityQuery request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<List<CityDto>>(await _unitOfWork.CityRepository.GetAllAsync(null, cancellationToken: cancellationToken));
        return result;
    }
}