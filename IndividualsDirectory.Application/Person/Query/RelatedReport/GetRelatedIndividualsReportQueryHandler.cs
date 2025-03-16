using IndividualsDirectory.Domain.Abstractions;
using IndividualsDirectory.Domain.Report;
using MediatR;

namespace IndividualsDirectory.Application.Person.Query.RelatedReport;

public class GetRelatedIndividualsReportQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetRelatedIndividualsReportQuery, List<RelatedIndividualsReportModel>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<List<RelatedIndividualsReportModel>> Handle(GetRelatedIndividualsReportQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.PersonRepository.GetRelatedIndividualsReportAsync(cancellationToken);
    }
}