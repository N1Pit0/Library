using Library.Application.DTOs.LoanDto;
using MediatR;

namespace Library.Application.Features.Commands.Loan.Delete;

public record DeleteLoanCommand(
    LoanDeleteDto LoanDeleteDto): IRequest<Unit>;
