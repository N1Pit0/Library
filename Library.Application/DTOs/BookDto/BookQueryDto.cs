using Library.Application.DTOs.AuthorDto;
using Library.Application.DTOs.LoanDto;

namespace Library.Application.DTOs.BookDto;

public class BookQueryDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public int Pages { get; set; }
    public int AuthorId { get; set; }
    public AuthorQueryDto? Author { get; set; }
    public bool IsAvailable { get; set; }
    public int CopiesAvailable { get; set; }
    public ICollection<LoanQueryDto> Loans { get; set; } = new List<LoanQueryDto>();
}