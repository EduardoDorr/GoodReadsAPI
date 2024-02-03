using MediatR;

using GoodReads.Core.Results;
using GoodReads.Application.Reports.GetBooksReadByUserInPeriod;

namespace GoodReads.Application.Reports.GetBooksReadyByUserInPeriod;

public sealed record GetBooksReadByUserInPeriodQuery(
    int Id,
    DateTime StartDate,
    DateTime FinishDate) : IRequest<Result<BooksReadByUserInPeriodViewModel>>;