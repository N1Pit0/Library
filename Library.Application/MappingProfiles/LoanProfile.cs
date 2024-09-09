using AutoMapper;
using Library.Application.DTOs.LoanDto;
using Library.Domain;

namespace Library.Application.MappingProfiles;

public class LoanProfile : Profile
{
    public LoanProfile()
    {
        // Mapping for LoanCreateDto to Loan
        CreateMap<LoanCreateDto, Loan>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())  // ID is auto-generated
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())  // Set automatically
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())  // Set automatically
            .ForMember(dest => dest.IsReturned, opt => opt.MapFrom(_ => false))  // Default to not returned
            .ForMember(dest => dest.FineAmount, opt => opt.Ignore())  // Fine handled separately
            .ForMember(dest => dest.Book, opt => opt.Ignore())  // Book relationship managed separately
            .ForMember(dest => dest.User, opt => opt.Ignore());  // User relationship managed separately

        // Mapping for LoanUpdateDto to Loan
        CreateMap<LoanUpdateDto, Loan>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))  // Update timestamp
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())  // Keep original created time
            .ForMember(dest => dest.Book, opt => opt.Ignore())  // Book relationship managed separately
            .ForMember(dest => dest.User, opt => opt.Ignore());  // User relationship managed separately

        // Mapping for LoanDeleteDto
        // No specific mapping needed for deletion since it's just the ID
        
        //Query All
        CreateMap<Loan, LoanQueryDto>();

    }
}