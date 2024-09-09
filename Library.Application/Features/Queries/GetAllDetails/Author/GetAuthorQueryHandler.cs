using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.AuthorDto;
using Library.Application.Logging;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.Author;

public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<AuthorQueryDto>>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<AuthorQueryDto> _logger;

    public GetAuthorQueryHandler(IAuthorRepository authorRepository,
        IMapper mapper,
        IAppLogger<AuthorQueryDto> logger)
    {
        _authorRepository = authorRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<AuthorQueryDto>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
    {
        // Retrieve all authors
        var authors = await _authorRepository.GetAllAsync();

        _logger.LogInformation("Author successfully queried");
        
        // Map authors to DTOs
        return _mapper.Map<List<AuthorQueryDto>>(authors);
    }
}
