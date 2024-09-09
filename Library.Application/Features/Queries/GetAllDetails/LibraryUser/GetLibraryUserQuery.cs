using Library.Application.DTOs.LibraryUserDto;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.LibraryUser;

public record GetLibraryUserQuery(
    ) : IRequest<List<LibraryUserQueryDto>>;
