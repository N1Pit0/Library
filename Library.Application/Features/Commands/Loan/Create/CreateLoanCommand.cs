using Library.Application.DTOs.LoanDto;
using MediatR;

namespace Library.Application.Features.Commands.Loan.Create;

public record CreateLoanCommand(
    LoanCreateDto LoanCreateDto) : IRequest<int>;

