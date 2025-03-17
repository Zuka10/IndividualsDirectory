using IndividualsDirectory.Application.Exceptions;
using IndividualsDirectory.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace IndividualsDirectory.Application.Person.Command.RemoveRelated;

public class RemoveRelatedPersonCommandHandler(IUnitOfWork unitOfWork, IMemoryCache memoryCache) : IRequestHandler<RemoveRelatedPersonCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMemoryCache _memoryCache = memoryCache;

    public async Task<bool> Handle(RemoveRelatedPersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _unitOfWork.PersonRepository.GetAsync(p => p.Id == request.PersonId, cancellationToken) ?? throw new PersonNotFoundException("Person with following id not found");

        await _unitOfWork.PersonRepository.DeleteRelatedIndividualAsync(request.PersonId, request.RelatedPersonId);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _memoryCache.Remove(CacheKeys.AllPersons);
        _memoryCache.Remove(CacheKeys.RelatedIndividualsReport);

        return true;
    }
}