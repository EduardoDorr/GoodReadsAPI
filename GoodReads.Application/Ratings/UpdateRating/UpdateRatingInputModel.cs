using GoodReads.Domain.Ratings;

namespace GoodReads.Application.Ratings.UpdateRating;

public sealed record UpdateRatingInputModel(
    RatingGrade Grade,
    string Description,
    DateTime StartDate,
    DateTime FinishDate,
    bool Active);