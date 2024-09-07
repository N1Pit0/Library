using Library.Application.DTOs.LoanDto;

namespace Library.Application.DTOs.LibraryUserDto;

public class LibraryUserQueryDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime RegistrationDate { get; set; }
    public DateTime? MembershipExpirationDate { get; set; }
    public ICollection<LoanQueryDto> Loans { get; set; } = new List<LoanQueryDto>();
}