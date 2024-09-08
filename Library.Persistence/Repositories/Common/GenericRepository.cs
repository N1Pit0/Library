using Library.Application.Contracts.Persistence;
using Library.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Repositories.Common;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly LibraryDbContext DbContext;

    public GenericRepository(LibraryDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await DbContext.Set<T>().FindAsync(id);
    }

    public async Task AddAsync(T entity)
    {
        await DbContext.Set<T>().AddAsync(entity);
        await DbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        DbContext.Set<T>().Update(entity);
        await DbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            DbContext.Set<T>().Remove(entity);
            await DbContext.SaveChangesAsync();
        }
    }
}