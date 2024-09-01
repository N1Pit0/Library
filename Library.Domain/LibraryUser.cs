using Library.Domain.Common;

namespace Library.Domain;

public class LibraryUser : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    public DateTime RegistrationDate { get; set; }
    public DateTime? MembershipExpirationDate { get; set; }

    public ICollection<Loan>? Loans { get; set; }
}