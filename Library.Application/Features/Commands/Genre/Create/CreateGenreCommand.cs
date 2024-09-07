using Library.Application.DTOs.GenreDto;
using MediatR;

namespace Library.Application.Features.Commands.Genre.Create;

public record CreateGenreCommand(
    GenreCreateDto GenreCreateDto) : IRequest<int>;

