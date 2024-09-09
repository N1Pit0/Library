using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.AuthorDto;
using Library.Application.Exceptions;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.Author.Single;

public class GetAuthorSingleQueryHandler: IRequestHandler<GetAuthorSingleQuery, AuthorQueryDto>

{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public GetAuthorSingleQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<AuthorQueryDto> Handle(GetAuthorSingleQuery request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetByIdAsync(request.Id);

        if (author == null)
        {
            throw new NotFoundException(nameof(Author), request.Id);
        }

        return _mapper.Map<AuthorQueryDto>(author);
    }
}