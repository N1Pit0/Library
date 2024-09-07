using MediatR;

namespace Library.Application.Features.Commands.Genre.Create;

public class CreateGenreHandler: 
    IRequestHandler<CreateGenreCommand, int>
{
    public Task<int> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}