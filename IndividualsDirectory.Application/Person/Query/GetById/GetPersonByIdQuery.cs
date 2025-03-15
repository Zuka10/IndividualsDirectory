using MediatR;

namespace IndividualsDirectory.Application.Person.Query.GetById;

public class GetPersonByIdQuery : IRequest<PersonDto>
{
    public int Id { get; set; }
}
