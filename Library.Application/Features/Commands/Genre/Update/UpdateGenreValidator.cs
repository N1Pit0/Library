using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.Features.Commands.Genre.Update;

public class UpdateGenreValidator : AbstractValidator<UpdateGenreCommand>
{
    private readonly IGenreRepository _genreRepository;

    public UpdateGenreValidator(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
        RuleFor(g => g.GenreUpdateDto.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");
    }
}
