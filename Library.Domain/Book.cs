using Library.Domain.Common;

namespace Library.Domain;

public class Book : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public DateTime PublishedDate { get; set; }
    public int Pages { get; set; }

    // Navigation Property
    public int AuthorId { get; set; }
    public Author Author { get; set; }

    // Availability Information
    public bool IsAvailable { get; set; }
    public int CopiesAvailable { get; set; }

    public ICollection<Loan>? Loans { get; set; }
}