using Library.Application.Contracts.Persistence;
using Library.Application.Exceptions;
using Library.Application.Logging;
using MediatR;

namespace Library.Application.Features.Commands.Genre.Delete;

public class DeleteGenreHandler : IRequestHandler<DeleteGenreCommand, Unit>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IAppLogger<DeleteGenreHandler> _logger;

    public DeleteGenreHandler(IGenreRepository genreRepository, IAppLogger<DeleteGenreHandler> logger)
    {
        _genreRepository = genreRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetByIdAsync(request.GenreDeleteDto.Id);

        if (genre == null)
        {
            throw new NotFoundException(nameof(Genre), request.GenreDeleteDto.Id);
        }

        await _genreRepository.DeleteAsync(genre.Id);

        _logger.LogInformation($"Genre with ID {genre.Id} was deleted successfully.");

        return Unit.Value;
    }
}
