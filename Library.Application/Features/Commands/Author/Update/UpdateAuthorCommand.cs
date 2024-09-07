using Library.Application.DTOs.AuthorDto;
using MediatR;

namespace Library.Application.Features.Commands.Author.Update;

public record UpdateAuthorCommand(
    AuthorUpdateDto AuthorUpdateDto): IRequest<Unit>;
