using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.Features.Commands.Genre.Create;

public class CreateGenreValidator : AbstractValidator<CreateGenreCommand>
{
    private readonly IGenreRepository _genreRepository;

    public CreateGenreValidator(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
        RuleFor(g => g.GenreCreateDto.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");
    }
}
