using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.Features.Commands.Author.Update;

public class UpdateAuthorValidator : AbstractValidator<UpdateAuthorCommand>
{
    private readonly IAuthorRepository _authorRepository;

    public UpdateAuthorValidator(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
        RuleFor(a => a.AuthorUpdateDto.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

        RuleFor(a => a.AuthorUpdateDto.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

        RuleFor(a => a.AuthorUpdateDto.BirthDate)
            .LessThan(DateTime.Now).WithMessage("Birthdate cannot be in the future");

        RuleFor(a => a.AuthorUpdateDto.Nationality)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");
    }
}
