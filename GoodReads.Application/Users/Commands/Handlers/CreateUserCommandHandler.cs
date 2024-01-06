using MediatR;
using AutoMapper;

using GoodReads.Domain.Entities;
using GoodReads.Domain.Interfaces;
using GoodReads.Domain.DomainResults;
using GoodReads.Domain.DomainResults.Errors;

namespace GoodReads.Application.Users.Commands.Handlers;

internal sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<int>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUserRepository donorRepository, IMapper mapper)
    {
        _userRepository = donorRepository;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var donor = _mapper.Map<User>(request);

        _userRepository.Create(donor);

        var created = true;//await _userRepository.SaveChangesAsync();

        if (!created)
            return UserErrors.CannotBeCreated;

        return donor.Id;
    }
}