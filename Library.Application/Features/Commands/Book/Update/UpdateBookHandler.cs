using AutoMapper;
using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.Exceptions;
using Library.Application.Logging;
using MediatR;

namespace Library.Application.Features.Commands.Book.Update;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<UpdateBookCommandHandler> _logger;

    public UpdateBookCommandHandler(
        IBookRepository bookRepository, 
        IMapper mapper, 
        IAppLogger<UpdateBookCommandHandler> logger)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        var validator = new UpdateBookValidator(_bookRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for UpdateBookCommand");
            throw new ValidationException(validationResult.Errors);
        }

        // Check if the book exists
        var existingBook = await _bookRepository.GetByIdAsync(request.BookUpdateDto.Id);

        if (existingBook == null)
        {
            throw new NotFoundException(nameof(Book), request.BookUpdateDto.Id);
        }

        // Map updated properties
        _mapper.Map(request.BookUpdateDto, existingBook);

        // Update the book
        await _bookRepository.UpdateAsync(existingBook);
        
        _logger.LogInformation($"Genre with ID {existingBook.Id} was updated successfully.");


        return Unit.Value;
    }
}
