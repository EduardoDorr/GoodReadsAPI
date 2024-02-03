using System.Net;

using MediatR;

using GoodReads.Core.Results;
using GoodReads.Core.Interfaces;
using GoodReads.Domain.Users;
using GoodReads.Domain.Interfaces;
using GoodReads.Application.Errors;

namespace GoodReads.Application.Users.DeleteUser;

internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
            return Result.Fail(new HttpStatusCodeError(UserErrors.NotFound, HttpStatusCode.NotFound));

        user.Deactivate();

        _userRepository.Update(user);

        var updated = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        if (!updated)
            return Result.Fail(UserErrors.CannotBeDeleted);

        return Result.Ok();
    }
}
