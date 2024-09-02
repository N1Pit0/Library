namespace Library.Application.DTOs.AuthorDto;

public class CreateAuthorDto
{
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public DateTime BirthDate { get; set; }
    
    public string Nationality { get; set; } = string.Empty;
    
    // Optionally, the user might provide book IDs if you want to associate books at creation time.
    public List<int> BookIds { get; set; } = new List<int>();
}