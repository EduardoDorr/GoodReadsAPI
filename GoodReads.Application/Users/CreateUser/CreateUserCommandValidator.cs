using FluentValidation;

namespace GoodReads.Application.Users.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(r => r.Name)
            .NotNull().WithMessage("Name is required")
            .NotEmpty().WithMessage("Name must not be null or empty")
            .MinimumLength(3).WithMessage("Name must have a minimum of 3 characters")
            .MaximumLength(100).WithMessage("Name must have a maximum of 100 characters");

        RuleFor(r => r.Email)
            .NotNull().WithMessage("Email is required")
            .NotEmpty().WithMessage("Email must not be null or empty")
            .EmailAddress().WithMessage("Email is invalid")
            .MinimumLength(5).WithMessage("Email must have a minimum of 5 characters")
            .MaximumLength(100).WithMessage("Email must have a maximum of 100 characters");
    }
}