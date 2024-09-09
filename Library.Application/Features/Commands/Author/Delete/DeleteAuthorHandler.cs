using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.Exceptions;
using Library.Application.Logging;
using MediatR;

namespace Library.Application.Features.Commands.Author.Delete;

public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IAppLogger<DeleteAuthorCommandHandler> _logger;
    

    public DeleteAuthorCommandHandler(
        IAuthorRepository authorRepository,
        IAppLogger<DeleteAuthorCommandHandler> logger)
    {
        _authorRepository = authorRepository;
        _logger = logger;
       
    }

    public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the author by ID
        var author = await _authorRepository.GetByIdAsync(request.AuthorDeleteDto.Id);
        if (author == null)
        {
            _logger.LogWarning("Author not found");
            throw new NotFoundException(nameof(Author), request.AuthorDeleteDto.Id);
        }

        // Delete the author
        await _authorRepository.DeleteAsync(author.Id);
        _logger.LogInformation("Author successfully deleted");

        return Unit.Value;
    }
}

