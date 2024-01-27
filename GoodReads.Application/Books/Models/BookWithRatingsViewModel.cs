using GoodReads.Domain.Books;
using GoodReads.Domain.Ratings;

namespace GoodReads.Application.Books.Models;

public record BookWithRatingsViewModel(
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
    ICollection<Rating> Ratings,
    bool Active);