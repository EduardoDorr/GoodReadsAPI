using MediatR;

using GoodReads.Domain.Interfaces;
using GoodReads.Domain.DomainResults;
using GoodReads.Domain.DomainResults.Errors;

namespace GoodReads.Application.Users.Commands.Handlers;

internal sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository donorRepository)
    {
        _userRepository = donorRepository;
    }

    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
            return UserErrors.NotFound;

        if (request.Active)
            user.Activate();
        else
            user.Deactivate();

        _userRepository.Update(user);

        var updated = true;//await _userRepository.SaveChangesAsync();

        if (!updated)
            return UserErrors.CannotBeUpdated;

        return Result.Ok();
    }
}