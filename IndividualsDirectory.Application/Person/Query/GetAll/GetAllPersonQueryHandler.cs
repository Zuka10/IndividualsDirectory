using AutoMapper;
using IndividualsDirectory.Domain.Abstractions;
using MediatR;

namespace IndividualsDirectory.Application.Person.Query.GetAll;

public class GetAllPersonQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetAllPersonQuery, List<PersonDto>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<List<PersonDto>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<List<PersonDto>>(await _unitOfWork.PersonRepository.GetAllAsNoTrackingAsync(p => p.Id > 0, cancellationToken: cancellationToken));
        return result;
    }
}