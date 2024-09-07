using Library.Application.DTOs.BookDto;

namespace Library.Application.DTOs.GenreDto;

public class GenreQueryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<BookQueryDto> Books { get; set; } = new List<BookQueryDto>();
}