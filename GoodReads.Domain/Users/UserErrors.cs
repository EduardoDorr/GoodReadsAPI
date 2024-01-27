using GoodReads.Core.Results.Errors;

namespace GoodReads.Domain.Users;

public record UserErrors(string Code, string Message) : IError
{
    public static readonly Error CannotBeCreated =
        new("User.CannotBeCreated", "Something went wrong and the user cannot be created");

    public static readonly Error CannotBeUpdated =
        new("User.CannotBeUpdated", "Something went wrong and the user cannot be updated");

    public static readonly Error CannotBeDeleted =
        new("User.CannotBeDeleted", "Something went wrong and the user cannot be deleted");

    public static readonly Error NotFound =
        new("User.NotFound", "Not found a valid user");
}