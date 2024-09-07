using Library.Application.DTOs.LibraryUserDto;
using MediatR;

namespace Library.Application.Features.Commands.LibraryUser.Update;

public record UpdateLibraryUserCommand(
    LibraryUserUpdateDto LibraryUserUpdateDto): IRequest<Unit>;
