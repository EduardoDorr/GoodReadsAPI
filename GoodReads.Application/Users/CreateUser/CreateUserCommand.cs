using MediatR;

using GoodReads.Core.Results;

namespace GoodReads.Application.Users.CreateUser;

public sealed record CreateUserCommand(string Name, string Email) : IRequest<Result<int>>;