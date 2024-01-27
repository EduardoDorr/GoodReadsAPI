using MediatR;

using GoodReads.Core.Results;
using GoodReads.Application.Users.Models;

namespace GoodReads.Application.Users.GetUser;

public sealed record GetUserQuery(int Id) : IRequest<Result<UserViewModel?>>;