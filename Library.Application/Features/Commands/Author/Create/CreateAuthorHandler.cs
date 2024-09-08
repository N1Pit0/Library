using AutoMapper;
using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.Logging;
using MediatR;

namespace Library.Application.Features.Commands.Author.Create;

using System.Threading;
using System.Threading.Tasks;

public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<CreateAuthorCommandHandler> _logger;

    public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper, IAppLogger<CreateAuthorCommandHandler> logger, IValidator<CreateAuthorCommand> validator)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        // Validate the command
        var validator = new CreateAuthorValidator(_authorRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for CreateAuthorCommand");
            throw new ValidationException(validationResult.Errors);
        }

        // Map the DTO to the Author entity
        var author = _mapper.Map<Domain.Author>(request.AuthorCreateDto);

        // Add the author to the database
        await _authorRepository.AddAsync(author);
        _logger.LogInformation("Author successfully created");

        return author.Id; // Returning the new author ID
    }
}


