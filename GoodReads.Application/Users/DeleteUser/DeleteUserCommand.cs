using MediatR;

using GoodReads.Core.Results;

namespace GoodReads.Application.Users.DeleteUser;

public record DeleteUserCommand(int Id) : IRequest<Result>;