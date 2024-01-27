using System.Net;

using MediatR;
using AutoMapper;

using GoodReads.Core.Results;
using GoodReads.Domain.Users;
using GoodReads.Domain.Interfaces;
using GoodReads.Application.Errors;
using GoodReads.Application.Users.Models;

namespace GoodReads.Application.Users.GetUser;

internal sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, Result<UserViewModel?>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(IUserRepository unitOfWork, IMapper mapper)
    {
        _userRepository = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Result<UserViewModel?>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.Id);

        if (user is null)
            return Result.Fail<UserViewModel?>(new HttpStatusCodeError(UserErrors.NotFound, HttpStatusCode.NotFound));

        var userViewModel = _mapper.Map<UserViewModel>(user);

        return Result.Ok(userViewModel);
    }
}