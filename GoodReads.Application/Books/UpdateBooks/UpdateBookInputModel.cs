using GoodReads.Domain.Books;

namespace GoodReads.Application.Books.UpdateBooks;

public sealed record UpdateBookInputModel(
    string Title,
    string Description,
    string Isbn,
    string Author,
    string Publisher,
    BookGenre Genre,
    int PublicationYear,
    int PrintLength,
    string CoverImage,
    bool Active);