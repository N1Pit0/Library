using AutoMapper;
using Library.Application.DTOs.AuthorDto;
using Library.Domain;

namespace Library.Application.MappingProfiles;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        // Mapping from CreateAuthorDto to Author (for creation)
        CreateMap<CreateAuthorDto, Author>()
            .ForMember(dest => dest.Books, opt => opt.Ignore());

        // Mapping from UpdateAuthorDto to Author (for updates)
        CreateMap<UpdateAuthorDto, Author>()
            .ForMember(dest => dest.Books, opt => opt.Ignore());
        
        // Delete DTO might not need mapping as it's just passing the Id
    }
}