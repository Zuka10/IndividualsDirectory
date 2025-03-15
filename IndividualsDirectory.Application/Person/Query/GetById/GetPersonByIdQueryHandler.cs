using AutoMapper;
using IndividualsDirectory.Domain.Abstractions;
using MediatR;

namespace IndividualsDirectory.Application.Person.Query.GetById;

public class GetPersonByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<GetPersonByIdQuery, PersonDto>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<PersonDto> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<PersonDto>(await _unitOfWork.PersonRepository.GetAsNoTrackingAsync(p => p.Id == request.Id, cancellationToken));
        return result;
    }
}