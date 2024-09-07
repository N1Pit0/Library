using MediatR;

namespace Library.Application.Features.Commands.Book.Update;

public class UpdateBookHandler:
    IRequestHandler<UpdateBookCommand, Unit>
{
    public Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}