using Library.Application.DTOs.AuthorDto;
using MediatR;

namespace Library.Application.Features.Commands.Author.Create;

public record CreateAuthorCommand(
    AuthorCreateDto AuthorCreateDto) : IRequest<int>;
