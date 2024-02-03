using Refit;

namespace GoodReads.Infrastructure.BooksGateway.GoogleBooksApi;

public interface IGoogleBooksApi
{
    [Get("/books/v1/volumes?q=isbn:{Isbn}&key={ApiKey}")]
    Task<GoogleBooksDto?> GetBookByIsbnAsync(string isbn, string apiKey);

    [Get("/books/v1/volumes?q={Title}&key={ApiKey}")]
    Task<GoogleBooksDto?> GetBooksByTitleAsync(string title, string apiKey);
}