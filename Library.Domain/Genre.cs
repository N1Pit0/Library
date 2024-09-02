namespace Library.Domain;

public class Genre
{
    public int Id { get; set; }  // Primary Key
    public string Name { get; set; } = string.Empty;

    // Navigation Property
    public ICollection<Book> Books { get; set; }
}