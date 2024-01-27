using MediatR;
using AutoMapper;

using GoodReads.Core.Results;
using GoodReads.Core.Interfaces;
using GoodReads.Domain.Users;
using GoodReads.Domain.Interfaces;

namespace GoodReads.Application.Users.CreateUser;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);

        _userRepository.Create(user);

        var created = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        if (!created)
            return Result.Fail<int>(UserErrors.CannotBeCreated);

        return Result.Ok(user.Id);
    }
}