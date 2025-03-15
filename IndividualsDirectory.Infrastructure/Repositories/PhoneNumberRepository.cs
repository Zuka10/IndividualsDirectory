using IndividualsDirectory.Domain.Abstractions;
using IndividualsDirectory.Domain.Entities;

namespace IndividualsDirectory.Infrastructure.Repositories;

public sealed class PhoneNumberRepository(IndividualsDbContext context) : BaseRepository<PhoneNumber>(context), IPhoneNumberRepository { }