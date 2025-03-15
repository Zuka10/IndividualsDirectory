using IndividualsDirectory.Domain.Abstractions;
using IndividualsDirectory.Domain.Entities;

namespace IndividualsDirectory.Infrastructure.Repositories;

public sealed class RelatedIndividualRepository(IndividualsDbContext context) : BaseRepository<RelatedIndividual>(context), IRelatedIndividualRepository { }