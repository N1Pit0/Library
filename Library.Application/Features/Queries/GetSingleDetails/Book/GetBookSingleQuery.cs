using Library.Application.DTOs.BookDto;
using MediatR;

namespace Library.Application.Features.Queries.GetSingleDetails.Book;

public record GetBookSingleQuery(int Id):
    IRequest<BookQueryDto>;