using Library.Application.DTOs.BookDto;
using MediatR;

namespace Library.Application.Features.Commands.Book.Update;

public record UpdateBookCommand(
    BookUpdateDto BookUpdateDto): IRequest<Unit>;
