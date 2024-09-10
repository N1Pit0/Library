using Library.Application.DTOs.GenreDto;
using MediatR;

namespace Library.Application.Features.Queries.GetSingleDetails.Genre;

public record GetGenreSingleQuery(int Id):
    IRequest<GenreQueryDto>;