using AutoMapper;
using IndividualsDirectory.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace IndividualsDirectory.Application.Person.Command.Create;

public class CreatePersonCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache) : IRequestHandler<CreatePersonCommand, int>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IMemoryCache _memoryCache = memoryCache;

    public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var person = _mapper.Map<Domain.Entities.Person>(request);
        var phoneNumbers = _mapper.Map<List<Domain.Entities.PhoneNumber>>(request.PhoneNumbers);
        var relatedIndividuals = _mapper.Map<List<Domain.Entities.RelatedIndividual>>(request.RelatedIndividuals);

        person.PhoneNumbers = phoneNumbers;
        person.RelatedIndividuals = relatedIndividuals;

        await _unitOfWork.PersonRepository.AddAsync(person, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        _memoryCache.Remove(CacheKeys.AllPersons);
        _memoryCache.Remove(CacheKeys.RelatedIndividualsReport);

        return person.Id;
    }
}