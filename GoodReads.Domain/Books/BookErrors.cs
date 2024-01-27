using GoodReads.Core.Results.Errors;

namespace GoodReads.Domain.Books;

public record BookErrors(string Code, string Message) : IError
{
    public static readonly Error CannotBeCreated =
        new("Book.CannotBeCreated", "Something went wrong and the book cannot be created");

    public static readonly Error CannotBeUpdated =
        new("Book.CannotBeUpdated", "Something went wrong and the book cannot be updated");

    public static readonly Error CannotBeDeleted =
        new("Book.CannotBeDeleted", "Something went wrong and the book cannot be deleted");

    public static readonly Error NotFound =
        new("Book.NotFound", "Not found");
}