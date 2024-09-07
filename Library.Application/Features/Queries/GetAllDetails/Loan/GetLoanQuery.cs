using Library.Application.DTOs.LoanDto;
using MediatR;

namespace Library.Application.Features.Queries.GetAllDetails.Loan;

public record GetLoanQuery(
    LoanQueryDto LoanQueryDto) : IRequest<List<LoanQueryDto>>;
