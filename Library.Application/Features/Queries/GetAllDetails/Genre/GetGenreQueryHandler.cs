using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.GenreDto;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.Genre;

public class GetGenreQueryHandler : IRequestHandler<GetGenreQuery, List<GenreQueryDto>>
{
    private readonly IGenreRepository _genreRepository;
    private readonly IMapper _mapper;

    public GetGenreQueryHandler(IGenreRepository genreRepository, IMapper mapper)
    {
        _genreRepository = genreRepository;
        _mapper = mapper;
    }
    
    public async Task<List<GenreQueryDto>> Handle(GetGenreQuery request, CancellationToken cancellationToken)
    {
        // Retrieve all authors
        var genres = await _genreRepository.GetAllAsync();

        // Map authors to DTOs
        return _mapper.Map<List<GenreQueryDto>>(genres);
    }
}