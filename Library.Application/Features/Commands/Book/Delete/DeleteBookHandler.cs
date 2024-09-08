using Library.Application.Contracts.Persistence;
using Library.Application.Exceptions;
using Library.Application.Logging;
using MediatR;

namespace Library.Application.Features.Commands.Book.Delete;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
{
    private readonly IBookRepository _bookRepository;
    private readonly IAppLogger<DeleteBookCommandHandler> _logger;

    public DeleteBookCommandHandler(
        IBookRepository bookRepository, 
        IAppLogger<DeleteBookCommandHandler> logger)
    {
        _bookRepository = bookRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        // Check if the book exists
        var book = await _bookRepository.GetByIdAsync(request.BookDeleteDto.Id);

        if (book == null)
        {
            throw new NotFoundException(nameof(Book), request.BookDeleteDto.Id);
        }

        // Delete the book
        await _bookRepository.DeleteAsync(book.Id);

        _logger.LogInformation($"Book with ID {book.Id} was deleted.");

        return Unit.Value;
    }
}
