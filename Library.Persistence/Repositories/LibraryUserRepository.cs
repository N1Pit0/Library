using Library.Application.Contracts.Persistence;
using Library.Domain;
using Library.Persistence.DatabaseContext;
using Library.Persistence.Repositories.Common;

namespace Library.Persistence.Repositories;

public class LibraryUserRepository : GenericRepository<LibraryUser>, ILibraryUserRepository
{
    public LibraryUserRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }

    // Additional methods specific to the Author entity can be implemented here
}