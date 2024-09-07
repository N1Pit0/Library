using Library.Application.DTOs.LibraryUserDto;
using MediatR;

namespace Library.Application.Features.Commands.LibraryUser.Create;

public record CreateLibraryUserCommand(
    LibraryUserCreateDto LibraryUserCreateDto) : IRequest<int>;
