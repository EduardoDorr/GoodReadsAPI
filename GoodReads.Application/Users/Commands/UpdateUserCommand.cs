using MediatR;

using GoodReads.Domain.DomainResults;

namespace GoodReads.Application.Users.Commands;

public sealed record UpdateUserCommand(int Id, bool Active) : IRequest<Result>;