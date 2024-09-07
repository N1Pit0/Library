using Library.Application.DTOs.AuthorDto;
using MediatR;

namespace Library.Application.Features.Commands.Author.Delete;

public record DeleteAuthorCommand(
    AuthorDeleteDto AuthorDeleteDto) : IRequest<Unit>;
