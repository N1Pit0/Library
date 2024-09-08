using AutoMapper;
using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.Logging;
using MediatR;

namespace Library.Application.Features.Commands.Genre.Create;

public class CreateGenreHandler : IRequestHandler<CreateGenreCommand, int>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IAppLogger<CreateGenreHandler> _logger;
    private readonly IMapper _mapper;

    public CreateGenreHandler(
        IGenreRepository genreRepository,
        IAppLogger<CreateGenreHandler> logger,
        IMapper mapper)
    {
        _genreRepository = genreRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateGenreValidator(_genreRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for CreateGenreCommand");
            throw new ValidationException(validationResult.Errors);
        }

        var genre = _mapper.Map<Domain.Genre>(request.GenreCreateDto);

        await _genreRepository.AddAsync(genre);

        _logger.LogInformation($"Genre with ID {genre.Id} was created successfully.");

        return genre.Id;
    }
}
