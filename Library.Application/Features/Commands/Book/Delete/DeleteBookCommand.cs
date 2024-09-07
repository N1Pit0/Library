using Library.Application.DTOs.BookDto;
using MediatR;

namespace Library.Application.Features.Commands.Book.Delete;

public record DeleteBookCommand(
    BookDeleteDto BookDeleteDto) : IRequest<Unit>;