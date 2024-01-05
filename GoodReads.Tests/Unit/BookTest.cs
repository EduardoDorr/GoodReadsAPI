using GoodReads.Tests.Utils;

namespace GoodReads.Tests.Unit;

public class BookTest
{
    [Fact]
    public void ABook_CreatedByBuilder_IsEqualToCreatedByConstructor()
    {
        // Arrange
        var bookCreatedByConstructor = BookUtils.CreateBook();

        // Act
        var bookCreatedByBuilder = BookBuilder
            .CreateBuilder("Test Title", "1594872315946")
            .WithDescription("Test Description")
            .WithAuthor("Test Author")
            .WithPublisher("Test Publisher")
            .WithGender(BookGender.Mystery)
            .WithPublicationYear(2000)
            .WithPrintLength(350)
            .WithCoverImage("sdflkijhfsia978346r5owaf")
            .Build();

        // Assert
        Assert.Equal(bookCreatedByConstructor.Title, bookCreatedByBuilder.Title);
        Assert.Equal(bookCreatedByConstructor.Isbn, bookCreatedByBuilder.Isbn);
        Assert.Equal(bookCreatedByConstructor.Description, bookCreatedByBuilder.Description);
        Assert.Equal(bookCreatedByConstructor.Author, bookCreatedByBuilder.Author);
        Assert.Equal(bookCreatedByConstructor.Publisher, bookCreatedByBuilder.Publisher);
        Assert.Equal(bookCreatedByConstructor.Gender, bookCreatedByBuilder.Gender);
        Assert.Equal(bookCreatedByConstructor.PublicationYear, bookCreatedByBuilder.PublicationYear);
        Assert.Equal(bookCreatedByConstructor.PrintLength, bookCreatedByBuilder.PrintLength);
        Assert.Equal(bookCreatedByConstructor.CoverImage, bookCreatedByBuilder.CoverImage);
    }
}