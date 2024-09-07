using Library.Application.DTOs.LoanDto;
using MediatR;

namespace Library.Application.Features.Commands.Loan.Update;

public record UpdateLoanCommand(
    LoanUpdateDto LoanUpdateDto): IRequest<Unit>;
