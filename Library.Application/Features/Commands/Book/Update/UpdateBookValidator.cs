using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.Features.Commands.Book.Update;

public class UpdateBookValidator : AbstractValidator<UpdateBookCommand>
{
    private readonly IBookRepository _bookRepository;

    public UpdateBookValidator(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
        RuleFor(b => b.BookUpdateDto.Title)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");

        RuleFor(b => b.BookUpdateDto.Isbn)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .Length(13).WithMessage("{PropertyName} must be 13 characters");

        RuleFor(b => b.BookUpdateDto.PublishedDate)
            .LessThan(DateTime.Now).WithMessage("Published Date cannot be in the future");

        RuleFor(b => b.BookUpdateDto.AuthorId)
            .GreaterThan(0).WithMessage("Author must be specified");

        RuleFor(b => b.BookUpdateDto.CopiesAvailable)
            .GreaterThanOrEqualTo(0).WithMessage("Copies available cannot be negative");
    }
}
