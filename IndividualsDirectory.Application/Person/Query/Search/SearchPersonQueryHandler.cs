using AutoMapper;
using IndividualsDirectory.Domain.Abstractions;
using MediatR;

namespace IndividualsDirectory.Application.Person.Query.Search;

public class SearchPersonQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<SearchPersonQuery, List<PersonDto>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<List<PersonDto>> Handle(SearchPersonQuery request, CancellationToken cancellationToken)
    {
        if(string.IsNullOrEmpty(request.SearchTerm))
        {
            return [];
        }

        int skip = (request.PageNumber - 1) * request.PageSize;
        int take = request.PageSize;

        var persons = await _unitOfWork.PersonRepository
            .SearchAsync(request.SearchTerm, skip, take);

        var result = _mapper.Map<List<PersonDto>>(persons);
        return result;
    }
}