using MediatR;

using GoodReads.Core.Results;
using GoodReads.Core.Interfaces;
using GoodReads.Domain.Ratings;
using GoodReads.Domain.Interfaces;

namespace GoodReads.Application.Ratings.DeleteRating;

public sealed class DeleteRatingCommandHandler : IRequestHandler<DeleteRatingCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRatingRepository _ratingRepository;

    public DeleteRatingCommandHandler(IUnitOfWork unitOfWork, IRatingRepository ratingRepository)
    {
        _unitOfWork = unitOfWork;
        _ratingRepository = ratingRepository;
    }

    public async Task<Result> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
    {
        var rating = await _ratingRepository.GetByIdAsync(request.Id);

        if (rating is null)
            return Result.Fail(RatingErrors.NotFound);

        rating.Deactivate();

        var updated = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        if (!updated)
            return Result.Fail(RatingErrors.CannotBeDeleted);

        return Result.Ok();
    }
}