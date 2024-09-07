using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.Features.Commands.Author.Create;

public class CreateAuthorValidator : AbstractValidator<CreateAuthorCommand>
{
    private readonly IAuthorRepository _authorRepository;

    public CreateAuthorValidator(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
        RuleFor(a => a.AuthorCreateDto.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

        RuleFor(a => a.AuthorCreateDto.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

        RuleFor(a => a.AuthorCreateDto.BirthDate)
            .LessThan(DateTime.Now).WithMessage("Birthdate cannot be in the future");

        RuleFor(a => a.AuthorCreateDto.Nationality)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");
    }
}
