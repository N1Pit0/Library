using AutoMapper;
using Library.Application.DTOs.GenreDto;
using Library.Domain;

namespace Library.Application.MappingProfiles;

public class GenreProfile : Profile
{
    public GenreProfile()
    {
        // Mapping for GenreCreateDto to Genre
        CreateMap<GenreCreateDto, Genre>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())  // ID is auto-generated
            .ForMember(dest => dest.Books, opt => opt.Ignore());  // Books are managed separately

        // Mapping for GenreUpdateDto to Genre
        CreateMap<GenreUpdateDto, Genre>()
            .ForMember(dest => dest.Books, opt => opt.Ignore());  // Books are managed separately

        // Mapping for GenreDeleteDto
        // No specific mapping needed for deletion since it's just the ID
    }
}