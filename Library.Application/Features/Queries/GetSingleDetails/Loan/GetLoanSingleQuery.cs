using Library.Application.DTOs.LoanDto;
using MediatR;

namespace Library.Application.Features.Queries.GetSingleDetails.Loan;

public record GetLoanSingleQuery(int Id)
    :IRequest<LoanQueryDto>;