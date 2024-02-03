using GoodReads.Domain.Books;

namespace GoodReads.Application.ExternalBooksApi.Models;

public sealed record ExternalBooksApiViewModel(int TotalBooks, IReadOnlyList<ExternalBooksApiViewModelItem> Books);

public sealed record ExternalBooksApiViewModelItem(
    string Id,
    string Title,
    string Description,
    string Isbn,
    BookGenre Genre,
    string Author,
    string Publisher,
    string PublicationYear,
    int PrintLength,
    string CoverImage
);