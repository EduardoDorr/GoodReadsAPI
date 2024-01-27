using GoodReads.Core.Results;
using GoodReads.Domain.Books;
using GoodReads.Domain.Ratings;

namespace GoodReads.Domain.Services;

public sealed class RatingService : IRatingService
{
    public Result Evaluate(Rating rating, Book book)
    {
        var result = ComputeNewAverageRatingAndNumberOfRatings(rating.Grade, book.AverageRating, book.NumberOfRatings);

        if (!result.Success)
            return Result.Fail(result.Errors);

        var (AverageRating, NumberOfRatings) = result.ValueOrDefault;

        book.UpdateRating(AverageRating, NumberOfRatings);

        return Result.Ok();
    }

    private static Result<(decimal AverageRating, int NumberOfRatings)> ComputeNewAverageRatingAndNumberOfRatings(
        RatingGrade ratingGrade, decimal currentAverageRating, int currentNumberOfRatings)
    {
        var newNumberOfRatings = currentNumberOfRatings + 1;

        if (newNumberOfRatings <= 0)
            return Result.Fail<(decimal, int)>(RatingErrors.NumberOfRatingIsZeroOrLess);

        var newAverageRating = ((currentAverageRating * currentNumberOfRatings) + (int)ratingGrade) / newNumberOfRatings;

        return Result.Ok((newAverageRating, newNumberOfRatings));
    }
}