using AutoMapper;
using Library.Application.DTOs.BookDto;
using Library.Domain;

namespace Library.Application.MappingProfiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        // Mapping for BookCreateDto to Book
        CreateMap<BookCreateDto, Book>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())  // ID is auto-generated
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Loans, opt => opt.Ignore());  // Loans managed separately

        // Mapping for BookUpdateDto to Book
        CreateMap<BookUpdateDto, Book>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))  // Set the updated time
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())  // Keep original created time
            .ForMember(dest => dest.Loans, opt => opt.Ignore());  // Loans managed separately

        // Mapping for BookDeleteDto
        // No specific mapping needed for deletion since it's just the ID
        
        //QueryAll
        CreateMap<Book, BookQueryDto>()
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author))
            .ForMember(dest => dest.Loans, opt => opt.MapFrom(src => src.Loans));

    }
}