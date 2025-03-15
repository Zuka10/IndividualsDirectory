using IndividualsDirectory.Domain.Report;
using MediatR;

namespace IndividualsDirectory.Application.Person.Query.RelatedReport;

public class GetRelatedIndividualsReportQuery : IRequest<List<RelatedIndividualsReportModel>> { }