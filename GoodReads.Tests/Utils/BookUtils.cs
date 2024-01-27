using GoodReads.Domain.Books;

namespace GoodReads.Tests.Utils;

internal static class BookUtils
{
    public static Book CreateBook()
    {
        return new Book("Test Title",
                        "Test Description",
                        "1594872315946",
                        "Test Author",
                        "Test Publisher",
                        BookGenre.Mystery,
                        2000,
                        350,
                        "sdflkijhfsia978346r5owaf");
    }
}