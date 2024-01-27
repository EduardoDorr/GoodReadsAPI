using GoodReads.Core.Results.Errors;

namespace GoodReads.Domain.Ratings;

public record RatingErrors(string Code, string Message) : IError
{
    public static readonly Error CannotBeCreated =
        new("Rating.CannotBeCreated", "Something went wrong and the rating cannot be created");

    public static readonly Error CannotBeUpdated =
        new("Rating.CannotBeUpdated", "Something went wrong and the rating cannot be updated");

    public static readonly Error CannotBeDeleted =
        new("Rating.CannotBeDeleted", "Something went wrong and the rating cannot be deleted");

    public static readonly Error NumberOfRatingIsZeroOrLess =
        new("Rating.NumberOfRatingIsZeroOrLess", "The number of rating is zero or less");

    public static readonly Error NotFound =
        new("Rating.NotFound", "Not found a valid rating");
}