using Library.Application.Contracts.Persistence;
using Library.Domain;
using Library.Persistence.DatabaseContext;
using Library.Persistence.Repositories.Common;

namespace Library.Persistence.Repositories;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }

    // Additional methods specific to the Book entity can be implemented here
}