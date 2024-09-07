using Library.Application.DTOs.GenreDto;
using MediatR;

namespace Library.Application.Features.Commands.Genre.Delete;

public record DeleteGenreCommand(
    GenreDeleteDto GenreDeleteDto): IRequest<Unit>;
