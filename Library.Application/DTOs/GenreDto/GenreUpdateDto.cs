namespace Library.Application.DTOs.GenreDto;

public class GenreUpdateDto
{
    public int Id { get; set; }  // ID of the genre being updated
    public string Name { get; set; } = string.Empty;
}