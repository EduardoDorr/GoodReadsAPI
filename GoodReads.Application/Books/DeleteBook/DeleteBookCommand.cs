using MediatR;

using GoodReads.Core.Results;

namespace GoodReads.Application.Books.DeleteBook;

public sealed record DeleteBookCommand(int Id) : IRequest<Result>;