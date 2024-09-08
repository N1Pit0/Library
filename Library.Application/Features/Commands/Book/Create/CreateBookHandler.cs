using AutoMapper;
using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.Logging;
using MediatR;

namespace Library.Application.Features.Commands.Book.Create;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<CreateBookCommandHandler> _logger;

    public CreateBookCommandHandler(
        IBookRepository bookRepository, 
        IMapper mapper, 
        IAppLogger<CreateBookCommandHandler> logger)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        // Validate the request
        var validator = new CreateBookValidator(_bookRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for CreateBookCommand");
            throw new ValidationException(validationResult.Errors);
        }

        // Map DTO to Entity
        var book = _mapper.Map<Domain.Book>(request.BookCreateDto);

        // Add book to the repository
        await _bookRepository.AddAsync(book);
        
        _logger.LogInformation($"Genre with ID {book.Id} was created successfully.");

        return book.Id;
    }
}
