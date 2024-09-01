using Library.Domain.Common;

namespace Library.Domain;

public class Loan : BaseEntity
{
    public int BookId { get; set; }
    public Book Book { get; set; }
    
    public int UserId { get; set; }
    public LibraryUser User { get; set; }
    
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }

    public bool IsReturned { get; set; }
    public decimal? FineAmount { get; set; }
}