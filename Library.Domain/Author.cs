using Library.Domain.Common;

namespace Library.Domain;

public class Author : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string Nationality { get; set; } = string.Empty;

    public ICollection<Book>? Books { get; set; }
}