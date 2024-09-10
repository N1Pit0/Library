using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.BookDto;
using Library.Application.Exceptions;
using MediatR;

namespace Library.Application.Features.Queries.GetSingleDetails.Book;

public class GetBookSingleQueryHandler: IRequestHandler<GetBookSingleQuery, BookQueryDto>

{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetBookSingleQueryHandler(IMapper mapper, IBookRepository bookRepository)
    {
        _mapper = mapper;
        _bookRepository = bookRepository;
    }

    public async Task<BookQueryDto> Handle(GetBookSingleQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);

        if (book == null)
        {
            throw new NotFoundException(nameof(GetAllDetails.Book), request.Id);
        }

        return _mapper.Map<BookQueryDto>(book);
    }
}