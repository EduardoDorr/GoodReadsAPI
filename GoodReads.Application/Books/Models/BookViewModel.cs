using GoodReads.Domain.Books;

namespace GoodReads.Application.Books.Models;

public record BookViewModel(
    int Id,
    string Title,
    string Description,
    string Isbn,
    string Author,
    string Publisher,
    BookGenre Genre,
    int PublicationYear,
    int PrintLength,
    decimal AverageRating,
    string CoverImage,
    bool Active);