using MediatR;

namespace Library.Application.Features.Commands.Author.Delete;

public class DeleteAuthorHandler:
    IRequestHandler<DeleteAuthorCommand, Unit>
{
    public Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
