using IndividualsDirectory.Domain.Abstractions;
using IndividualsDirectory.Domain.Entities;

namespace IndividualsDirectory.Infrastructure.Repositories;

public sealed class PersonRepository(IndividualsDbContext context) : BaseRepository<Person>(context), IPersonRepository { }