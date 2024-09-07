using MediatR;

namespace Library.Application.Features.Commands.Author.Update;

public class UpdateAuthorHandler:
    IRequestHandler<UpdateAuthorCommand, Unit>
{
    public Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}