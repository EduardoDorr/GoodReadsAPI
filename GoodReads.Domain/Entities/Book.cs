using GoodReads.Domain.Enums;

namespace GoodReads.Domain.Entities;

public class Book : BaseEntity
{
    public string Title { get; protected set; }
    public string Description { get; private set; }
    public string Isbn { get; private set; }
    public string Author { get; private set; }
    public string Publisher { get; private set; }
    public BookGender Gender { get; private set; }
    public int PublicationYear { get; private set; }
    public int PrintLength { get; private set; }
    public decimal AverageRating { get; private set; }
    public string CoverImage { get; private set; }

    public virtual ICollection<Rating> Ratings { get; private set; }

    protected Book() { }

    public Book(string title, string isbn)
    {
        Title = title;
        Isbn = isbn;
    }

    public Book(string title, string description, string isbn,
                string author, string publisher, BookGender gender,
                int publicationYear, int printLength, string coverImage)
    {
        Title = title;
        Description = description;
        Isbn = isbn;
        Author = author;
        Publisher = publisher;
        Gender = gender;
        PublicationYear = publicationYear;
        PrintLength = printLength;
        CoverImage = coverImage;
        Ratings = new List<Rating>();

        Active = true;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
}