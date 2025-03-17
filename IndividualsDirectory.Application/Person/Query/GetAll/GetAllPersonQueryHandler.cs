using AutoMapper;
using IndividualsDirectory.Domain.Abstractions;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace IndividualsDirectory.Application.Person.Query.GetAll;

public class GetAllPersonQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IMemoryCache memoryCache, IConfiguration configuration) : IRequestHandler<GetAllPersonQuery, List<PersonDto>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IMemoryCache _memoryCache = memoryCache;
    private readonly int _absoluteExpiration = configuration.GetValue<int>("CacheSettings:AbsoluteExpirationMinutes");
    private readonly int _slidingExpiration = configuration.GetValue<int>("CacheSettings:SlidingExpirationMinutes");

    public async Task<List<PersonDto>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
    {
        if (_memoryCache.TryGetValue(CacheKeys.AllPersons, out List<PersonDto>? cachedPersons))
        {
            return cachedPersons!;
        }

        var result = _mapper.Map<List<PersonDto>>(await _unitOfWork.PersonRepository.GetAllAsNoTrackingAsync(p => p.Id > 0, cancellationToken: cancellationToken));

        _memoryCache.Set(CacheKeys.AllPersons, result, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_absoluteExpiration),
            SlidingExpiration = TimeSpan.FromMinutes(_slidingExpiration)
        });

        return result;
    }
}