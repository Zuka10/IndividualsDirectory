using IndividualsDirectory.Application.Exceptions;
using IndividualsDirectory.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace IndividualsDirectory.Application.Person.Command.AddRelated;

public class AddRelatedPersonCommandHandler(IUnitOfWork unitOfWork, IMemoryCache memoryCache) : IRequestHandler<AddRelatedPersonCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMemoryCache _memoryCache = memoryCache;

    public async Task<bool> Handle(AddRelatedPersonCommand request, CancellationToken cancellationToken)
    {
        if (request.PersonId == request.RelatedPersonId) throw new RelatedPersonIsSameAsPersonException("Person and related person cannot be the same");

        var person = await _unitOfWork.PersonRepository.GetAsync(p => p.Id == request.PersonId, cancellationToken)
            ?? throw new PersonNotFoundException($"Person with following id: {request.PersonId} not found");

        var relatedPerson = await _unitOfWork.PersonRepository.GetAsync(p => p.Id == request.RelatedPersonId, cancellationToken)
            ?? throw new PersonNotFoundException($"Related person with following id: {request.RelatedPersonId} not found");

        await _unitOfWork.PersonRepository.AddRelatedIndividualAsync(person.Id, relatedPerson.Id, request.Relationship);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _memoryCache.Remove(CacheKeys.AllPersons);
        _memoryCache.Remove(CacheKeys.RelatedIndividualsReport);

        return true;
    }
}