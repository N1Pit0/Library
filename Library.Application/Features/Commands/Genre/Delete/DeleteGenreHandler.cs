using MediatR;

namespace Library.Application.Features.Commands.Genre.Delete;

public class DeleteGenreHandler:
    IRequestHandler<DeleteGenreCommand, Unit>
{
    public Task<Unit> Handle(DeleteGenreCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}