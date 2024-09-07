using Library.Application.DTOs.LibraryUserDto;
using MediatR;

namespace Library.Application.Features.Commands.LibraryUser.Delete;

public record DeleteLibraryUserCommand(
    LibraryUserDeleteDto LibraryUserDeleteDto): IRequest<Unit>;
