using MediatR;

namespace Library.Application.Features.Commands.LibraryUser.Create;

public class CreateLibraryUserHandler:
    IRequestHandler<CreateLibraryUserCommand, int>
{
    public Task<int> Handle(CreateLibraryUserCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}