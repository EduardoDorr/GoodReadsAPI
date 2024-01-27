using FluentValidation;

namespace GoodReads.Application.Ratings.CreateRating;

public class CreateRatingCommandValidator : AbstractValidator<CreateRatingCommand>
{
    public CreateRatingCommandValidator()
    {
        RuleFor(r => r.Grade)
            .NotNull().WithMessage("Grade is required")
            .NotEmpty().WithMessage("Grade must not be null or empty")
            .IsInEnum().WithMessage("Grade must match the specific types");

        RuleFor(r => r.Description)
            .NotNull().WithMessage("Description is required")
            .NotEmpty().WithMessage("Description must not be null or empty")
            .MinimumLength(5).WithMessage("Description must have a minimum of 5 characters")
            .MaximumLength(255).WithMessage("Description must have a maximum of 255 characters");

        RuleFor(r => r.StartDate)
            .NotEmpty().WithMessage("StartDate must not be null or empty")
            .Must((r, startDate) => startDate < r.FinishDate).WithMessage("FinishDate must be later than StartDate");

        RuleFor(r => r.UserId)
           .GreaterThan(0)
           .WithMessage("UserId must be valid");            

        RuleFor(r => r.BookId)
           .GreaterThan(0)
           .WithMessage("BookId must be valid");
    }
}