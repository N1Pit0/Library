using Library.Application.DTOs.LibraryUserDto;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.LibraryUser;

public class GetLibraryUserQueryHandler : IRequestHandler<GetLibraryUserQuery, List<LibraryUserQueryDto>>
{
    public Task<List<LibraryUserQueryDto>> Handle(GetLibraryUserQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}