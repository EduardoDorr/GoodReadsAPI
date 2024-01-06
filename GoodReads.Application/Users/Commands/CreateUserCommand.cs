using MediatR;

using GoodReads.Domain.DomainResults;

namespace GoodReads.Application.Users.Commands;

public sealed record CreateUserCommand(string Name, string Email) : IRequest<Result<int>>;