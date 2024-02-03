using MediatR;

using GoodReads.Core.Results;
using GoodReads.Application.ExternalBooksApi.Models;

namespace GoodReads.Application.ExternalBooksApi.GetBooksByTitle;

public sealed record GetBooksByTitleRequest(string Title) : IRequest<Result<ExternalBooksApiViewModel?>>;