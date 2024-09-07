using Library.Application.DTOs.BookDto;
using MediatR;

namespace Library.Application.Features.Commands.Book.Create;

public record CreateBookCommand(
    BookCreateDto BookCreateDto) : IRequest<int>;

