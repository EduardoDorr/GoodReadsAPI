using MediatR;
using AutoMapper;

using GoodReads.Core.Results;
using GoodReads.Domain.Users;
using GoodReads.Domain.Interfaces;
using GoodReads.Application.Users.Models;
using GoodReads.Application.Reports.GetBooksReadyByUserInPeriod;

namespace GoodReads.Application.Reports.GetBooksReadByUserInPeriod;

public sealed class GetBooksReadByUserInPeriodQueryHandler : IRequestHandler<GetBooksReadByUserInPeriodQuery, Result<BooksReadByUserInPeriodViewModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetBooksReadByUserInPeriodQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Result<BooksReadByUserInPeriodViewModel>> Handle(GetBooksReadByUserInPeriodQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetWithRatingsInPeriodByIdAsync(request.Id, request.StartDate, request.FinishDate);

        if (user is null)
            return Result.Fail<BooksReadByUserInPeriodViewModel>(UserErrors.NotFound);

        var userViewModel = _mapper.Map<UserViewModel>(user);

        var totalBooksRead = user.Ratings.Count;

        var booksReadViewModel =
            new BooksReadByUserInPeriodViewModel(
                userViewModel,
                request.StartDate,
                request.FinishDate,
                totalBooksRead);

        return Result.Ok(booksReadViewModel);
    }
}
