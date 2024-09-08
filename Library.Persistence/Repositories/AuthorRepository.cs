using Library.Application.Contracts.Persistence;
using Library.Domain;
using Library.Persistence.DatabaseContext;
using Library.Persistence.Repositories.Common;

namespace Library.Persistence.Repositories;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
{
    public AuthorRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }

    // Additional methods specific to the Author entity can be implemented here
    public Task<IEnumerable<Author>> GetAuthorsByNationality(string nationality)
    {
        throw new NotImplementedException();
    }
}