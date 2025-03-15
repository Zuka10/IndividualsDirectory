using IndividualsDirectory.Domain.Abstractions;
using IndividualsDirectory.Domain.Entities;

namespace IndividualsDirectory.Infrastructure.Repositories;

public sealed class CityRepository(IndividualsDbContext context) : BaseRepository<City>(context), ICityRepository { }