using MediatR;

using GoodReads.Core.Results;
using GoodReads.Application.Users.Models;

namespace GoodReads.Application.Users.GetUserWithRatings;

public sealed record GetUserWithRatingsQuery(int Id) : IRequest<Result<UserWithRatingsViewModel?>>;