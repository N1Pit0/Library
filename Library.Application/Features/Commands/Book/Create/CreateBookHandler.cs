using MediatR;

namespace Library.Application.Features.Commands.Book.Create;

public class CreateBookHandler:
    IRequestHandler<CreateBookCommand, int>
{
    public Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}