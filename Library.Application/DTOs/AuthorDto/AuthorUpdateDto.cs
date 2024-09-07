namespace Library.Application.DTOs.AuthorDto;

public class AuthorUpdateDto
{
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public DateTime BirthDate { get; set; }
    
    public string Nationality { get; set; } = string.Empty;

    public List<int> BookIds { get; set; } = new List<int>();
}