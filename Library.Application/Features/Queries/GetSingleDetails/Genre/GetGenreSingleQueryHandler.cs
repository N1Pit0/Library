using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.GenreDto;
using Library.Application.Exceptions;
using MediatR;

namespace Library.Application.Features.Queries.GetSingleDetails.Genre;

public class GetGenreSingleQueryHandler: IRequestHandler<GetGenreSingleQuery, GenreQueryDto>

{
    private readonly IMapper _mapper;
    private readonly IGenreRepository _genreRepository;

    public GetGenreSingleQueryHandler(
        IMapper mapper,
        IGenreRepository genreRepository)
    {
        _mapper = mapper;
        _genreRepository = genreRepository;
    }

    public async Task<GenreQueryDto> Handle(GetGenreSingleQuery request, CancellationToken cancellationToken)
    {
        var genre = await _genreRepository.GetByIdAsync(request.Id);

        if (genre == null)
        {
            throw new NotFoundException(nameof(GetAllDetails.Genre), request.Id);
        }

        return _mapper.Map<GenreQueryDto>(genre);
    }
}