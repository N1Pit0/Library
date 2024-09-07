using MediatR;

namespace Library.Application.Features.Commands.LibraryUser.Delete;

public class DeleteLibraryUserHandler:
    IRequestHandler<DeleteLibraryUserCommand, Unit>
{
    public Task<Unit> Handle(DeleteLibraryUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}