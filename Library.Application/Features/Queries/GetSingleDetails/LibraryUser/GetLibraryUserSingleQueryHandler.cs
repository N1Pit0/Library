using AutoMapper;
using Library.Application.Contracts.Persistence;
using Library.Application.DTOs.LibraryUserDto;
using Library.Application.Exceptions;
using MediatR;

namespace Library.Application.Features.Queries.GetSingleDetails.LibraryUser;

public class GetLibraryUserSingleQueryHandler: IRequestHandler<GetLibraryUserSingleQuery, LibraryUserQueryDto>

{
    private readonly IMapper _mapper;
    private readonly ILibraryUserRepository _libraryUserRepository;

    public GetLibraryUserSingleQueryHandler(
        IMapper mapper,
        ILibraryUserRepository libraryUserRepository)
    {
        _mapper = mapper;
        _libraryUserRepository = libraryUserRepository;
    }

    public async Task<LibraryUserQueryDto> Handle(GetLibraryUserSingleQuery request, CancellationToken cancellationToken)
    {
        var libraryUser = await _libraryUserRepository.GetByIdAsync(request.Id);

        if (libraryUser == null)
        {
            throw new NotFoundException(nameof(GetAllDetails.LibraryUser), request.Id);
        }

        return _mapper.Map<LibraryUserQueryDto>(libraryUser);
    }
}