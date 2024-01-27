using MediatR;

using GoodReads.Core.Results;
using GoodReads.Domain.Books;

namespace GoodReads.Application.Books.CreateBook;

public sealed record CreateBookCommand(
    string Title,
    string Description,
    string Isbn,
    string Author,
    string Publisher,
    BookGenre Genre,
    int PublicationYear,
    int PrintLength,
    string CoverImage) : IRequest<Result<int>>;