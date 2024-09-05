namespace Library.Application.DTOs.LoanDto;

public class LoanCreateDto
{
    public int BookId { get; set; }
    public int UserId { get; set; }
    public DateTime LoanDate { get; set; }
}