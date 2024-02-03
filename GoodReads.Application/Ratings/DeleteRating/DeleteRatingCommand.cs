using MediatR;

using GoodReads.Core.Results;

namespace GoodReads.Application.Ratings.DeleteRating;

public sealed record DeleteRatingCommand(int Id) : IRequest<Result>;