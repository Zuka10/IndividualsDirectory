using MediatR;

namespace IndividualsDirectory.Application.Person.Query.Search;

public class SearchPersonQuery : IRequest<List<PersonDto>>
{
    public string SearchTerm { get; set; } = null!;
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}