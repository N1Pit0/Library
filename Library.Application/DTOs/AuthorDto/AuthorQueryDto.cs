using Library.Application.DTOs.BookDto;

namespace Library.Application.DTOs.AuthorDto;

public class AuthorQueryDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string Nationality { get; set; } = string.Empty;
    public ICollection<BookQueryDto> Books { get; set; } = new List<BookQueryDto>();
}