using MediatR;

using GoodReads.Core.Results;

namespace GoodReads.Application.Users.UpdateUser;

public sealed record UpdateUserCommand(int Id, string Name, string Email, bool Active) : IRequest<Result>;