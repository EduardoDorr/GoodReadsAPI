using MediatR;

using GoodReads.Core.Models;
using GoodReads.Core.Results;
using GoodReads.Application.Users.Models;

namespace GoodReads.Application.Users.GetUsers;

public sealed record GetUsersQuery(int Page = 1, int PageSize = 10) : IRequest<Result<PaginationResult<UserViewModel>>>;