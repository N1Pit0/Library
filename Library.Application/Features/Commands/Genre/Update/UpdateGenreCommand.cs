using Library.Application.DTOs.GenreDto;
using MediatR;

namespace Library.Application.Features.Commands.Genre.Update;

public record UpdateGenreCommand(
    GenreUpdateDto GenreUpdateDto): IRequest<Unit>;
