using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.BookDto;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.Book;

public class GetBookQueryHandler : IRequestHandler<GetBookQuery, List<BookQueryDto>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<List<BookQueryDto>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var books = await _bookRepository.GetAllAsync();

        // Map authors to DTOs
        return _mapper.Map<List<BookQueryDto>>(books);
    }
}