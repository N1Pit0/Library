using AutoMapper;
using Library.Application.DTOs.LibraryUserDto;
using Library.Domain;

namespace Library.Application.MappingProfiles;

public class LibraryUserProfile : Profile
{
    public LibraryUserProfile()
    {
        // Mapping for LibraryUserCreateDto to LibraryUser
        CreateMap<LibraryUserCreateDto, LibraryUser>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())  // ID is auto-generated
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())  // Set automatically
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())  // Set automatically
            .ForMember(dest => dest.Loans, opt => opt.Ignore());  // Loans are managed separately

        // Mapping for LibraryUserUpdateDto to LibraryUser
        CreateMap<LibraryUserUpdateDto, LibraryUser>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))  // Set update time
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())  // Keep original created time
            .ForMember(dest => dest.Loans, opt => opt.Ignore());  // Loans are managed separately

        // Mapping for LibraryUserDeleteDto
        // No specific mapping needed for deletion since it's just the ID
    }
}