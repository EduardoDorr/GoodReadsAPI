using FluentValidation;

namespace GoodReads.Application.Books.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotNull().WithMessage("Title is required")
            .NotEmpty().WithMessage("Title must not be null or empty")
            .MinimumLength(3).WithMessage("Title must have a minimum of 3 characters")
            .MaximumLength(200).WithMessage("Title must have a maximum of 200 characters");

        RuleFor(r => r.Description)
            .NotNull().WithMessage("Description is required")
            .NotEmpty().WithMessage("Description must not be null or empty")
            .MinimumLength(5).WithMessage("Description must have a minimum of 5 characters")
            .MaximumLength(255).WithMessage("Description must have a maximum of 255 characters");

        RuleFor(r => r.Isbn)
            .NotNull().WithMessage("Isbn is required")
            .NotEmpty().WithMessage("Isbn must not be null or empty")
            .Length(13).WithMessage("Isbn must have 13 characters");

        RuleFor(r => r.Author)
            .NotNull().WithMessage("Author is required")
            .NotEmpty().WithMessage("Author must not be null or empty")
            .MinimumLength(5).WithMessage("Author must have a minimum of 5 characters")
            .MaximumLength(100).WithMessage("Author must have a maximum of 100 characters");

        RuleFor(r => r.Publisher)
            .NotNull().WithMessage("Publisher is required")
            .NotEmpty().WithMessage("Publisher must not be null or empty")
            .MinimumLength(5).WithMessage("Publisher must have a minimum of 5 characters")
            .MaximumLength(50).WithMessage("Publisher must have a maximum of 50 characters");

        RuleFor(r => r.Genre)
            .NotNull().WithMessage("Genre is required")
            .NotEmpty().WithMessage("Genre must not be null or empty")
            .IsInEnum().WithMessage("Genre must match the specific types");

        RuleFor(b => b.PublicationYear)
            .GreaterThan(0)
            .WithMessage("Publication year must be valid");

        RuleFor(r => r.PrintLength)
            .GreaterThan(0)
            .WithMessage("Print lenght must be valid");

        RuleFor(r => r.CoverImage)
            .NotNull().WithMessage("Cover image is required")
            .NotEmpty().WithMessage("Cover image must not be null or empty")
            .MinimumLength(5).WithMessage("Cover image must have a minimum of 5 characters")
            .MaximumLength(255).WithMessage("Cover image must have a maximum of 255 characters");
    }
}