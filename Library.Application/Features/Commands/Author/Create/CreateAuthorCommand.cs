using MediatR;

namespace Library.Application.Features.Commands.Author.Create;

public class CreateAuthorCommand : IRequest<int>
{
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;
    
    public DateTime BirthDate { get; set; }
    
    public string Nationality { get; set; } = string.Empty;

    public ICollection<Domain.Book> Books { get; set; }  = new List<Domain.Book>();
}