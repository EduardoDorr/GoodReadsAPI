namespace GoodReads.Domain.DomainResults.Errors;

public record UserErrors(string Code, string Message) : IError
{
    public static readonly Error CannotBeCreated =
        new("User.CannotBeCreated", "Something went wrong and the user cannot be created");

    public static readonly Error CannotBeUpdated =
        new("User.CannotBeUpdated", "Something went wrong and the user cannot be updated");

    public static readonly Error NotFound =
        new("User.NotFound", "Not found a valid user");
}