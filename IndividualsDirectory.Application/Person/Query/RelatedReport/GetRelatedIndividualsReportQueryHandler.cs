using IndividualsDirectory.Domain.Abstractions;
using IndividualsDirectory.Domain.Report;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace IndividualsDirectory.Application.Person.Query.RelatedReport;

public class GetRelatedIndividualsReportQueryHandler(IUnitOfWork unitOfWork, IMemoryCache memoryCache, IConfiguration configuration) : IRequestHandler<GetRelatedIndividualsReportQuery, List<RelatedIndividualsReportModel>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMemoryCache _memoryCache = memoryCache;
    private readonly int _absoluteExpiration = configuration.GetValue<int>("CacheSettings:AbsoluteExpirationMinutes");
    private readonly int _slidingExpiration = configuration.GetValue<int>("CacheSettings:SlidingExpirationMinutes");

    public async Task<List<RelatedIndividualsReportModel>> Handle(GetRelatedIndividualsReportQuery request, CancellationToken cancellationToken)
    {
        if(_memoryCache.TryGetValue(CacheKeys.RelatedIndividualsReport, out List<RelatedIndividualsReportModel>? cacheResult))
        {
            return cacheResult!;
        }

        var result = await _unitOfWork.PersonRepository.GetRelatedIndividualsReportAsync(cancellationToken);

        _memoryCache.Set(CacheKeys.RelatedIndividualsReport, result, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(_absoluteExpiration),
            SlidingExpiration = TimeSpan.FromMinutes(_slidingExpiration)
        });

        return result;
    }
}