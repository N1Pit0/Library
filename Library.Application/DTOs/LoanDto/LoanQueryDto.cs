using Library.Application.DTOs.BookDto;
using Library.Application.DTOs.LibraryUserDto;

namespace Library.Application.DTOs.LoanDto;

public class LoanQueryDto
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public BookQueryDto? Book { get; set; }
    public int UserId { get; set; }
    public LibraryUserQueryDto? User { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsReturned { get; set; }
    public decimal? FineAmount { get; set; }
}