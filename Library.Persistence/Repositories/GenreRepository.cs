using Library.Application.Contracts.Persistence;
using Library.Domain;
using Library.Persistence.DatabaseContext;
using Library.Persistence.Repositories.Common;

namespace Library.Persistence.Repositories;

public class GenreRepository : GenericRepository<Genre>, IGenreRepository
{
    public GenreRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }

    // Additional methods specific to the Author entity can be implemented here
}