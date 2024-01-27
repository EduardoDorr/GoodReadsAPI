using System.Net;

using MediatR;

using GoodReads.Core.Results;
using GoodReads.Core.Interfaces;
using GoodReads.Domain.Users;
using GoodReads.Domain.Interfaces;
using GoodReads.Application.Errors;

namespace GoodReads.Application.Users.UpdateUser;

internal sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
            return Result.Fail(new HttpStatusCodeError(UserErrors.NotFound, HttpStatusCode.NotFound));

        user.Update(request.Name, request.Email, request.Active);

        _userRepository.Update(user);

        var updated = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        if (!updated)
            return Result.Fail(UserErrors.CannotBeUpdated);

        return Result.Ok();
    }
}