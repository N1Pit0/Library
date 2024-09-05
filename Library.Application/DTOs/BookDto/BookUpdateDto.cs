namespace Library.Application.DTOs.BookDto;

public class BookUpdateDto
{
    public int Id { get; set; }  // ID of the book being updated
    public string Title { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public int Pages { get; set; }
    public int AuthorId { get; set; }  // Changing the author if necessary
    public int CopiesAvailable { get; set; }
    public bool IsAvailable { get; set; }
}
