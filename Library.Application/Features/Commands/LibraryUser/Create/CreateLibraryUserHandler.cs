using AutoMapper;
using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.Logging;
using MediatR;

namespace Library.Application.Features.Commands.LibraryUser.Create;

public class CreateLibraryUserCommandHandler : IRequestHandler<CreateLibraryUserCommand, int>
{
    private readonly ILibraryUserRepository _libraryUserRepository;
    private readonly IAppLogger<CreateLibraryUserCommandHandler> _logger;
    private readonly IMapper _mapper;

    public CreateLibraryUserCommandHandler(
        ILibraryUserRepository libraryUserRepository,
        IAppLogger<CreateLibraryUserCommandHandler> logger,
        IMapper mapper)
    {
        _libraryUserRepository = libraryUserRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateLibraryUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLibraryUserValidator(_libraryUserRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for CreateLibraryUserCommand");
            throw new ValidationException(validationResult.Errors);
        }

        var libraryUser = _mapper.Map<Domain.LibraryUser>(request.LibraryUserCreateDto);

        await _libraryUserRepository.AddAsync(libraryUser);

        _logger.LogInformation($"LibraryUser with ID {libraryUser.Id} was created successfully.");

        return libraryUser.Id;
    }
}
