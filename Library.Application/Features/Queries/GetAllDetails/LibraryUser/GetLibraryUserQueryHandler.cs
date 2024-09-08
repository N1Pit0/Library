using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.LibraryUserDto;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.LibraryUser;

public class GetLibraryUserQueryHandler : IRequestHandler<GetLibraryUserQuery, List<LibraryUserQueryDto>>
{
    private readonly ILibraryUserRepository _libraryUserRepository;
    private readonly IMapper _mapper;

    public GetLibraryUserQueryHandler(ILibraryUserRepository libraryUserRepository, IMapper mapper)
    {
        _libraryUserRepository = libraryUserRepository;
        _mapper = mapper;
    }
    
    public async Task<List<LibraryUserQueryDto>> Handle(GetLibraryUserQuery request, CancellationToken cancellationToken)
    {
        // Retrieve all authors
        var libraryUsers = await _libraryUserRepository.GetAllAsync();

        // Map authors to DTOs
        return _mapper.Map<List<LibraryUserQueryDto>>(libraryUsers);
    }
}