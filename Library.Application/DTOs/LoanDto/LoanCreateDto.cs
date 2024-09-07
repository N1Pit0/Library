namespace Library.Application.DTOs.LoanDto;

public class LoanCreateDto
{
    public int BookId { get; set; }    // Reference to Book
    public int UserId { get; set; }    // Reference to LibraryUser
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned { get; set; }
    public decimal? FineAmount { get; set; }
}
