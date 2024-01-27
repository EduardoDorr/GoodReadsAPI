using GoodReads.Domain.Books;

namespace GoodReads.Domain.Builders;

public class BookBuilder
{
    private readonly string _title;
    private readonly string _isbn;
    private string _description;
    private string _author;
    private string _publisher;
    private BookGenre _gender;
    private int _publicationYear;
    private int _printLength;
    private string _coverImage;

    private BookBuilder(string title, string isbn)
    {
        _title = title;
        _isbn = isbn;
    }

    public static BookBuilder CreateBuilder(string title, string isbn)
    {
        return new BookBuilder(title, isbn);
    }

    public BookBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public BookBuilder WithAuthor(string author)
    {
        _author = author;
        return this;
    }

    public BookBuilder WithPublisher(string publisher)
    {
        _publisher = publisher;
        return this;
    }

    public BookBuilder WithGender(BookGenre bookGender)
    {
        _gender = bookGender;
        return this;
    }

    public BookBuilder WithPublicationYear(int publicationYear)
    {
        _publicationYear = publicationYear;
        return this;
    }

    public BookBuilder WithPrintLength(int printLength)
    {
        _printLength = printLength;
        return this;
    }

    public BookBuilder WithCoverImage(string coverImage)
    {
        _coverImage = coverImage;
        return this;
    }

    public Book Build()
    {
        return new Book(_title, _description, _isbn,
                        _author, _publisher, _gender,
                        _publicationYear, _printLength, _coverImage);
    }
}