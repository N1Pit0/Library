using MediatR;

namespace Library.Application.Features.Commands.Book.Delete;

public class DeleteBookHandler:
    IRequestHandler<DeleteBookCommand, Unit>
{
    public Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}