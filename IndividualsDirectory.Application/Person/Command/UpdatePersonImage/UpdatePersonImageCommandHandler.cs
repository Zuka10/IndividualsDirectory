using IndividualsDirectory.Application.Exceptions;
using IndividualsDirectory.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace IndividualsDirectory.Application.Person.Command.UpdatePersonImage;

public class UpdatePersonImageCommandHandler(IUnitOfWork unitOfWork, IMemoryCache memoryCache) : IRequestHandler<UpdatePersonImageCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMemoryCache _memoryCache = memoryCache;

    public async Task<bool> Handle(UpdatePersonImageCommand request, CancellationToken cancellationToken)
    {
        var person = await _unitOfWork.PersonRepository.GetAsync(p => p.Id == request.Id, cancellationToken) ?? throw new PersonNotFoundException("person with following id not found");

        person.ImagePath = request.ImagePath;
        await _unitOfWork.PersonRepository.UpdateAsync(person, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _memoryCache.Remove(CacheKeys.AllPersons);
        _memoryCache.Remove(CacheKeys.RelatedIndividualsReport);

        return true;
    }
}