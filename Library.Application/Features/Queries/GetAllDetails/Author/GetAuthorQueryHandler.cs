using Library.Application.DTOs.AuthorDto;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.Author;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<AuthorQueryDto>>
{
    public Task<List<AuthorQueryDto>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}