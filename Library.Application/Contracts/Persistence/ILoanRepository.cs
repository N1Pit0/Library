using Library.Domain;

namespace Library.Application.Contracts.Persistence;

public interface ILoanRepository : IGenericRepository<Loan>
{
    Task<List<Loan>> GetLoansDueInDaysAsync(int days);
}