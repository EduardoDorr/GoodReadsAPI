using MediatR;

using GoodReads.Core.Results;
using GoodReads.Application.ExternalBooksApi.Models;

namespace GoodReads.Application.ExternalBooksApi.GetBookByIsbn;

public sealed record GetBookByIsbnRequest(string Isbn) : IRequest<Result<ExternalBooksApiViewModel?>>;