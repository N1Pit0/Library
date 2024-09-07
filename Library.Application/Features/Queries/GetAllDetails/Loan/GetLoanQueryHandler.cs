using Library.Application.DTOs.LoanDto;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.Loan;

public class GetLoanQueryHandler : IRequestHandler<GetLoanQuery, List<LoanQueryDto>>
{
    public Task<List<LoanQueryDto>> Handle(GetLoanQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}