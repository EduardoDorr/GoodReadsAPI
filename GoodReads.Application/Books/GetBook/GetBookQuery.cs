using MediatR;

using GoodReads.Core.Results;
using GoodReads.Application.Books.Models;

namespace GoodReads.Application.Books.GetBook;

public sealed record GetBookQuery(int Id) : IRequest<Result<BookViewModel?>>;