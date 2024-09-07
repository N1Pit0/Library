using Library.Application.DTOs.BookDto;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.Book;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery, List<BookQueryDto>>
{
    public Task<List<BookQueryDto>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}