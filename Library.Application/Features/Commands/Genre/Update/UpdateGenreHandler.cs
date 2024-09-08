using AutoMapper;
using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.Exceptions;
using Library.Application.Logging;
using MediatR;

namespace Library.Application.Features.Commands.Genre.Update;

public class UpdateGenreHandler : IRequestHandler<UpdateGenreCommand, Unit>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IAppLogger<UpdateGenreHandler> _logger;
    private readonly IMapper _mapper;

    public UpdateGenreHandler(
        IGenreRepository genreRepository,
        IAppLogger<UpdateGenreHandler> logger,
        IMapper mapper)
    {
        _genreRepository = genreRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateGenreValidator(_genreRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for UpdateGenreCommand");
            throw new ValidationException(validationResult.Errors);
        }

        var genre = await _genreRepository.GetByIdAsync(request.GenreUpdateDto.Id);

        if (genre == null)
        {
            throw new NotFoundException(nameof(Genre), request.GenreUpdateDto.Id);
        }

        _mapper.Map(request.GenreUpdateDto, genre);

        await _genreRepository.UpdateAsync(genre);

        _logger.LogInformation($"Genre with ID {genre.Id} was updated successfully.");

        return Unit.Value;
    }
}
