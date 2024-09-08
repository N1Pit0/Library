using Library.Application.Contracts.Persistence;
using Library.Application.Exceptions;
using Library.Application.Logging;
using MediatR;

namespace Library.Application.Features.Commands.LibraryUser.Delete;

public class DeleteLibraryUserCommandHandler : IRequestHandler<DeleteLibraryUserCommand, Unit>
{
    private readonly ILibraryUserRepository _libraryUserRepository;
    private readonly IAppLogger<DeleteLibraryUserCommandHandler> _logger;

    public DeleteLibraryUserCommandHandler(
        ILibraryUserRepository libraryUserRepository,
        IAppLogger<DeleteLibraryUserCommandHandler> logger)
    {
        _libraryUserRepository = libraryUserRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteLibraryUserCommand request, CancellationToken cancellationToken)
    {
        var libraryUser = await _libraryUserRepository.GetByIdAsync(request.LibraryUserDeleteDto.Id);

        if (libraryUser == null)
        {
            throw new NotFoundException(nameof(LibraryUser), request.LibraryUserDeleteDto.Id);
        }

        await _libraryUserRepository.DeleteAsync(libraryUser.Id);

        _logger.LogInformation($"LibraryUser with ID {libraryUser.Id} was deleted successfully.");

        return Unit.Value;
    }
}
