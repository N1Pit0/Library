using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.AuthorDto;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.Author;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<AuthorQueryDto>>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public GetAuthorQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<List<AuthorQueryDto>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        // Retrieve all authors
        var authors = await _authorRepository.GetAllAsync();

        // Map authors to DTOs
        return _mapper.Map<List<AuthorQueryDto>>(authors);
    }
}
