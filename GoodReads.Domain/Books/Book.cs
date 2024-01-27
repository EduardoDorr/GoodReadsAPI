using GoodReads.Core.Entities;
using GoodReads.Domain.Ratings;

namespace GoodReads.Domain.Books;

public class Book : BaseEntity
{
    public string Title { get; protected set; }
    public string Description { get; private set; }
    public string Isbn { get; private set; }
    public string Author { get; private set; }
    public string Publisher { get; private set; }
    public BookGenre Genre { get; private set; }
    public int PublicationYear { get; private set; }
    public int PrintLength { get; private set; }
    public decimal AverageRating { get; private set; }
    public string CoverImage { get; private set; }

    public int NumberOfRatings { get; private set; }

    public virtual ICollection<Rating> Ratings { get; private set; }

    protected Book() { }

    public Book(string title, string isbn)
    {
        Title = title;
        Isbn = isbn;

        Active = true;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public Book(string title, string description, string isbn,
                string author, string publisher, BookGenre genre,
                int publicationYear, int printLength, string coverImage)
    {
        Title = title;
        Description = description;
        Isbn = isbn;
        Author = author;
        Publisher = publisher;
        Genre = genre;
        PublicationYear = publicationYear;
        PrintLength = printLength;
        CoverImage = coverImage;
        NumberOfRatings = 0;
        Ratings = new List<Rating>();

        Active = true;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(string title, string description, string isbn,
                       string author, string publisher, BookGenre genre,
                       int publicationYear, int printLength, string coverImage, bool active)
    {
        Title = title;
        Description = description;
        Isbn = isbn;
        Author = author;
        Publisher = publisher;
        Genre = genre;
        PublicationYear = publicationYear;
        PrintLength = printLength;
        CoverImage = coverImage;
        Active = active;

        UpdatedAt = DateTime.Now;
    }

    public void UpdateRating(decimal averageRating, int numberOfRatings)
    {
        AverageRating = averageRating;
        NumberOfRatings = numberOfRatings;
    }
}