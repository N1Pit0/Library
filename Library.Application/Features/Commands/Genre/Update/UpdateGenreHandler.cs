using MediatR;

namespace Library.Application.Features.Commands.Genre.Update;

public class UpdateGenreHandler:
    IRequestHandler<UpdateGenreCommand, Unit>
{
    public Task<Unit> Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}