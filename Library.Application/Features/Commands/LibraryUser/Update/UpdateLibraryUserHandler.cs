using AutoMapper;
using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.Exceptions;
using Library.Application.Logging;
using MediatR;

namespace Library.Application.Features.Commands.LibraryUser.Update;

public class UpdateLibraryUserCommandHandler : IRequestHandler<UpdateLibraryUserCommand, Unit>
{
    private readonly ILibraryUserRepository _libraryUserRepository;
    private readonly IAppLogger<UpdateLibraryUserCommandHandler> _logger;
    private readonly IMapper _mapper;

    public UpdateLibraryUserCommandHandler(
        ILibraryUserRepository libraryUserRepository,
        IAppLogger<UpdateLibraryUserCommandHandler> logger,
        IMapper mapper)
    {
        _libraryUserRepository = libraryUserRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLibraryUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLibraryUserValidator(_libraryUserRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for UpdateLibraryUserCommand");
            throw new ValidationException(validationResult.Errors);
        }

        var libraryUser = await _libraryUserRepository.GetByIdAsync(request.LibraryUserUpdateDto.Id);

        if (libraryUser == null)
        {
            throw new NotFoundException(nameof(LibraryUser), request.LibraryUserUpdateDto.Id);
        }

        _mapper.Map(request.LibraryUserUpdateDto, libraryUser);

        await _libraryUserRepository.UpdateAsync(libraryUser);

        _logger.LogInformation($"LibraryUser with ID {libraryUser.Id} was updated successfully.");

        return Unit.Value;
    }
}
