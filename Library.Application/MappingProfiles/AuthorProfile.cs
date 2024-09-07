using AutoMapper;
using Library.Application.DTOs.AuthorDto;
using Library.Domain;

namespace Library.Application.MappingProfiles;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        // Mapping from CreateAuthorDto to Author (for creation)
        CreateMap<AuthorCreateDto, Author>()
            .ForMember(dest => dest.Books, opt => opt.Ignore());

        // Mapping from UpdateAuthorDto to Author (for updates)
        CreateMap<AuthorUpdateDto, Author>()
            .ForMember(dest => dest.Books, opt => opt.Ignore());
        
        // Delete DTO might not need mapping as it's just passing the id
        
        //QueryAll
        CreateMap<Author, AuthorQueryDto>()
            .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));

    }
    
}