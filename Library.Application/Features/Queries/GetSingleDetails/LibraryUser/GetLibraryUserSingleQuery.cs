using Library.Application.DTOs.LibraryUserDto;
using MediatR;

namespace Library.Application.Features.Queries.GetSingleDetails.LibraryUser;

public record GetLibraryUserSingleQuery(int Id):
    IRequest<LibraryUserQueryDto>;