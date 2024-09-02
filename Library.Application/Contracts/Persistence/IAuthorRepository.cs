using Library.Domain;

namespace Library.Application.Contracts.Persistence;

public interface IAuthorRepository: IGenericRepository<Author>
{
    Task<IEnumerable<Author>> GetAuthorsByNationality(string nationality);
}