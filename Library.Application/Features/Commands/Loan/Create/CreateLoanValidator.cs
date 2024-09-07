using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.Features.Commands.Loan.Create;

public class CreateLoanValidator : AbstractValidator<CreateLoanCommand>
{
    private readonly ILoanRepository _loanRepository;

    public CreateLoanValidator(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
        RuleFor(l => l.LoanCreateDto.BookId)
            .GreaterThan(0).WithMessage("Book must be specified");

        RuleFor(l => l.LoanCreateDto.UserId)
            .GreaterThan(0).WithMessage("Library User must be specified");

        RuleFor(l => l.LoanCreateDto.LoanDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Loan Date cannot be in the future");
    }
}
