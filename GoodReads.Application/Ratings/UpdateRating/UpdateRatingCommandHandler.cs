using MediatR;

using GoodReads.Core.Results;
using GoodReads.Core.Interfaces;
using GoodReads.Domain.Ratings;
using GoodReads.Domain.Interfaces;

namespace GoodReads.Application.Ratings.UpdateRating;

public sealed class UpdateRatingCommandHandler : IRequestHandler<UpdateRatingCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRatingRepository _ratingRepository;

    public UpdateRatingCommandHandler(IUnitOfWork unitOfWork, IRatingRepository ratingRepository)
    {
        _unitOfWork = unitOfWork;
        _ratingRepository = ratingRepository;
    }

    public async Task<Result> Handle(UpdateRatingCommand request, CancellationToken cancellationToken)
    {
        var rating = await _ratingRepository.GetByIdAsync(request.Id);

        if (rating is null)
            return Result.Fail(RatingErrors.NotFound);

        rating.Update(request.Grade, request.Description, request.StartDate, request.FinishDate, request.Active);

        _ratingRepository.Update(rating);

        var updated = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        if (!updated)
            return Result.Fail(RatingErrors.CannotBeUpdated);

        return Result.Ok();
    }
}
