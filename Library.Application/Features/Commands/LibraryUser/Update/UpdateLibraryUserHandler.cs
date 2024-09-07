using MediatR;

namespace Library.Application.Features.Commands.LibraryUser.Update;

public class UpdateLibraryUserHandler:
    IRequestHandler<UpdateLibraryUserCommand, Unit>
{
    public Task<Unit> Handle(UpdateLibraryUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}