using MediatR;
using AutoMapper;

using GoodReads.Core.Models;
using GoodReads.Core.Results;
using GoodReads.Domain.Interfaces;
using GoodReads.Application.Users.Models;

namespace GoodReads.Application.Users.GetUsers;

internal sealed class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, Result<PaginationResult<UserViewModel>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Result<PaginationResult<UserViewModel>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var paginationUsers = await _userRepository.GetAllAsync(request.Page, request.PageSize);

        var usersViewModel = _mapper.Map<List<UserViewModel>>(paginationUsers.Data);

        var paginationUsersViewModel =
            new PaginationResult<UserViewModel>
            (
                paginationUsers.Page,
                paginationUsers.PageSize,
                paginationUsers.TotalCount,
                paginationUsers.TotalPages,
                usersViewModel
            );

        return Result.Ok(paginationUsersViewModel);
    }
}