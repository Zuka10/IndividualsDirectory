using MediatR;

namespace IndividualsDirectory.Application.Person.Query.GetAll;

public class GetAllPersonQuery : IRequest<List<PersonDto>> { }