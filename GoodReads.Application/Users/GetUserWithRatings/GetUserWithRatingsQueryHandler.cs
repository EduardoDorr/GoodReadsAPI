using System.Net;

using MediatR;
using AutoMapper;

using GoodReads.Core.Results;
using GoodReads.Domain.Users;
using GoodReads.Domain.Interfaces;
using GoodReads.Application.Errors;
using GoodReads.Application.Users.Models;

namespace GoodReads.Application.Users.GetUserWithRatings;

public sealed class GetUserWithRatingsQueryHandler : IRequestHandler<GetUserWithRatingsQuery, Result<UserWithRatingsViewModel?>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserWithRatingsQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Result<UserWithRatingsViewModel?>> Handle(GetUserWithRatingsQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetWithRatingsByIdAsync(request.Id);

        if (user is null)
            return Result.Fail<UserWithRatingsViewModel?>(new HttpStatusCodeError(UserErrors.NotFound, HttpStatusCode.NotFound));

        var userWithRatingsViewModel = _mapper.Map<UserWithRatingsViewModel>(user);

        return Result.Ok(userWithRatingsViewModel);
    }
}
