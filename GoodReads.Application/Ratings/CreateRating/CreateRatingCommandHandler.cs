using MediatR;
using AutoMapper;

using GoodReads.Core.Results;
using GoodReads.Core.Interfaces;
using GoodReads.Domain.Users;
using GoodReads.Domain.Books;
using GoodReads.Domain.Ratings;
using GoodReads.Domain.Interfaces;
using GoodReads.Domain.Services;

namespace GoodReads.Application.Ratings.CreateRating;

public sealed class CreateRatingCommandHandler : IRequestHandler<CreateRatingCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IRatingRepository _ratingRepository;
    private readonly IRatingService _ratingService;
    private readonly IMapper _mapper;

    public CreateRatingCommandHandler(
        IUnitOfWork unitOfWork, 
        IUserRepository userRepository,
        IBookRepository bookRepository,
        IRatingRepository ratingRepository,
        IRatingService ratingService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _bookRepository = bookRepository;
        _ratingRepository = ratingRepository;
        _ratingService = ratingService;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user is null || !user.Active)
            return Result.Fail<int>(UserErrors.NotFound);

        var book = await _bookRepository.GetByIdAsync(request.BookId);

        if (book is null || !book.Active)
            return Result.Fail<int>(BookErrors.NotFound);

        var rating = _mapper.Map<Rating>(request);

        _ratingService.Evaluate(rating, book);

        _ratingRepository.Create(rating);

        _bookRepository.Update(book);

        var created = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        if (!created)
            return Result.Fail<int>(RatingErrors.CannotBeCreated);

        return Result.Ok(rating.Id);
    }
}