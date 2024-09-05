namespace Library.Application.DTOs.LoanDto;

public class LoanUpdateDto
{
    public int Id { get; set; }  // Loan identifier
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned { get; set; }
    public decimal? FineAmount { get; set; }
}