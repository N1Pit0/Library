using Library.Application.Contracts.Persistence;
using Library.Domain;
using Library.Persistence.DatabaseContext;
using Library.Persistence.Repositories.Common;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Repositories;

public class LoanRepository : GenericRepository<Loan>, ILoanRepository
{
    public LoanRepository(LibraryDbContext dbContext) : base(dbContext)
    {
    }
    
    public async Task<List<Loan>> GetLoansDueInDaysAsync(int days)
    {
        var dueDate = DateTime.Now.AddDays(days);

        return await DbContext.Loans
            .Include(l => l.User)
            .Include(l => l.Book)
            .Where(l => l.ReturnDate != null && l.ReturnDate.Value.Date == dueDate.Date && !l.IsReturned)
            .ToListAsync();
    }


    // Additional methods specific to the Loan entity can be implemented here
}