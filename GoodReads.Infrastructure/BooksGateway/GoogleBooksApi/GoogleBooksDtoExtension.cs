using GoodReads.Domain.Books;
using GoodReads.Application.ExternalBooksApi.Models;

namespace GoodReads.Infrastructure.BooksGateway.GoogleBooksApi;

public static class GoogleBooksDtoExtension
{
    private const string IDENTIFIER_TYPE = "ISBN_13";

    public static ExternalBooksApiViewModel ToViewModel(this GoogleBooksDto dto)
    {
        if (ValidateDto(dto))
            return new ExternalBooksApiViewModel(0, new List<ExternalBooksApiViewModelItem>());
                
        var books = new List<ExternalBooksApiViewModelItem>();

        foreach (var bookItem in dto.Items)
        {
            if (ValidateBook(bookItem))
                continue;

            var author = GetStringfyAuthors(bookItem.VolumeInfo.Authors);
            var publicationYear = GetPublicationYear(bookItem.VolumeInfo.PublishedDate);
            var isbn = GetIsbn13(bookItem.VolumeInfo.IndustryIdentifiers);
            var coverImage = GetCoverImage(bookItem.VolumeInfo.ImageLinks);
            Enum.TryParse(bookItem.VolumeInfo.Categories.FirstOrDefault(), out BookGenre genre);

            books.Add(
                new ExternalBooksApiViewModelItem(
                    bookItem.Id,
                    bookItem.VolumeInfo.Title,
                    bookItem.VolumeInfo.Description,
                    isbn,
                    genre,
                    author,
                    bookItem.VolumeInfo.Publisher,
                    publicationYear,
                    bookItem.VolumeInfo.PageCount,
                    coverImage
                    )
                );
        }

        var totalBooks = books.Count;

        var externalBooksApiViewModel = new ExternalBooksApiViewModel(totalBooks, books);

        return externalBooksApiViewModel;
    }

    private static bool ValidateDto(GoogleBooksDto dto)
    {
        return dto is null || dto.Items is null;
    }

    private static bool ValidateBook(Item bookItem)
    {
        return bookItem is null ||
               bookItem.VolumeInfo is null ||
               bookItem.VolumeInfo.ImageLinks is null ||
               bookItem.VolumeInfo.Categories is null ||
               bookItem.VolumeInfo.IndustryIdentifiers is null;
    }

    private static string GetStringfyAuthors(IReadOnlyList<string> authors)
    {
        if (authors is null || authors.Count == 0)
            return string.Empty;

        return string.Join(';', authors);
    }

    private static string GetPublicationYear(string publishedDate)
    {
        if (string.IsNullOrWhiteSpace(publishedDate))
            return string.Empty;

        var publishedDateSplitted = publishedDate.Split('-');

        if (publishedDateSplitted.Length == 0)
            return string.Empty;

        return publishedDateSplitted[0];
    }

    private static string GetIsbn13(IReadOnlyList<IndustryIdentifier> industryIdentifiers)
    {
        if (industryIdentifiers is null || industryIdentifiers.Count == 0)
            return string.Empty;

        var isbn13Identifier = industryIdentifiers
            .FirstOrDefault(i => i.Type == IDENTIFIER_TYPE);

        return isbn13Identifier?.Identifier ?? string.Empty;
    }

    private static string GetCoverImage(ImageLinks imageLinks)
    {
        if (imageLinks is null || string.IsNullOrWhiteSpace(imageLinks.Thumbnail))
            return string.Empty;

        return imageLinks.Thumbnail;
    }
}