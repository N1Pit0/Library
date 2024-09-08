using AutoMapper;
using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.Exceptions;
using Library.Application.Logging;
using MediatR;

namespace Library.Application.Features.Commands.Author.Update;

public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<UpdateAuthorCommandHandler> _logger;
    public UpdateAuthorCommandHandler(
        IAuthorRepository authorRepository,
        IMapper mapper,
        IAppLogger<UpdateAuthorCommandHandler> logger
        )
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        // Validate the command
        var validator = new UpdateAuthorValidator(_authorRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for UpdateAuthorCommand");
            throw new ValidationException(validationResult.Errors);
        }

        // Retrieve the author by ID
        var author = await _authorRepository.GetByIdAsync(request.AuthorUpdateDto.Id);

        if (author == null)
        {
            _logger.LogWarning("Author not found");
            throw new NotFoundException(nameof(Author), request.AuthorUpdateDto.Id);
        }

        // Map the changes to the author entity
        _mapper.Map(request.AuthorUpdateDto, author);

        // Update the author in the database
        await _authorRepository.UpdateAsync(author);
        _logger.LogInformation("Author successfully updated");

        return Unit.Value;
    }
}
