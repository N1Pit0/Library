namespace Library.Application.DTOs.BookDto;

public class BookCreateDto
{
    public string Title { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public int Pages { get; set; }
    public int CopiesAvailable { get; set; }
    public int AuthorId { get; set; }  // Reference to Author
}
