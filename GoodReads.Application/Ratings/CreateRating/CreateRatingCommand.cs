using MediatR;

using GoodReads.Core.Results;
using GoodReads.Domain.Ratings;

namespace GoodReads.Application.Ratings.CreateRating;

public sealed record CreateRatingCommand(
    RatingGrade Grade,
    string Description,
    DateTime StartDate,
    DateTime FinishDate,
    int UserId,
    int BookId) : IRequest<Result<int>>;