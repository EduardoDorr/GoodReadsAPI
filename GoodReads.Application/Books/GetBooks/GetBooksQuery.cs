using MediatR;

using GoodReads.Core.Models;
using GoodReads.Core.Results;
using GoodReads.Application.Books.Models;

namespace GoodReads.Application.Books.GetBooks;

public sealed record GetBooksQuery(int Page = 1, int PageSize = 10) : IRequest<Result<PaginationResult<BookViewModel>>>;