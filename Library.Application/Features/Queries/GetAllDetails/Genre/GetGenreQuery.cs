using Library.Application.DTOs.GenreDto;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.Genre;

public record GetGenreQuery(
    ) : IRequest<List<GenreQueryDto>>;
