using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.Features.Commands.Book.Create;

public class CreateBookValidator : AbstractValidator<CreateBookCommand>
{
    private readonly IBookRepository _bookRepository;

    public CreateBookValidator(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
        RuleFor(b => b.BookCreateDto.Title)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

        RuleFor(b => b.BookCreateDto.Isbn)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .Length(13).WithMessage("{PropertyName} must be 13 characters");

        RuleFor(b => b.BookCreateDto.PublishedDate)
            .LessThan(DateTime.Now).WithMessage("Published Date cannot be in the future");

        RuleFor(b => b.BookCreateDto.AuthorId)
            .GreaterThan(0).WithMessage("Author must be specified");

        RuleFor(b => b.BookCreateDto.CopiesAvailable)
            .GreaterThanOrEqualTo(0).WithMessage("Copies available cannot be negative");
    }
}
