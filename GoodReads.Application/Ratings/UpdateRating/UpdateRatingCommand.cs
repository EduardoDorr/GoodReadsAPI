using MediatR;

using GoodReads.Core.Results;
using GoodReads.Domain.Ratings;

namespace GoodReads.Application.Ratings.UpdateRating;

public sealed record UpdateRatingCommand(
    int Id,
    RatingGrade Grade,
    string Description,
    DateTime StartDate,
    DateTime FinishDate,
    bool Active) : IRequest<Result>;