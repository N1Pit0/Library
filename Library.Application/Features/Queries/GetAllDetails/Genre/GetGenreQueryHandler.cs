using Library.Application.DTOs.GenreDto;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.Genre;

public class GetGenreQueryHandler : IRequestHandler<GetGenreQuery, List<GenreQueryDto>>
{
    public Task<List<GenreQueryDto>> Handle(GetGenreQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}