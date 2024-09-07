using Library.Application.DTOs.BookDto;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.Book;

public record GetBookQuery(
    BookQueryDto BookQueryDto) : IRequest<List<BookQueryDto>>;
