using IndividualsDirectory.Application.Exceptions;
using IndividualsDirectory.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace IndividualsDirectory.Application.Person.Command.Delete;

public class DeletePersonCommandHandler(IUnitOfWork unitOfWork, IMemoryCache memoryCache) : IRequestHandler<DeletePersonCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMemoryCache _memoryCache = memoryCache;

    public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var person = await _unitOfWork.PersonRepository.GetAsync(p => p.Id == request.Id, cancellationToken) ?? throw new PersonNotFoundException("person with following id not found");

        _unitOfWork.PersonRepository.Remove(person);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _memoryCache.Remove(CacheKeys.AllPersons);
        _memoryCache.Remove(CacheKeys.RelatedIndividualsReport);

        return true;
    }
}