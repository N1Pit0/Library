using FluentValidation;
using Library.Application.Contracts.Persistence;

namespace Library.Application.Features.Commands.Loan.Update;

public class UpdateLoanValidator : AbstractValidator<UpdateLoanCommand>
{
    private readonly ILoanRepository _loanRepository;

    public UpdateLoanValidator(ILoanRepository loanRepository)
    {
        _loanRepository = loanRepository;
        RuleFor(l => l.LoanUpdateDto.BookId)
            .GreaterThan(0).WithMessage("Book must be specified");

        RuleFor(l => l.LoanUpdateDto.UserId)
            .GreaterThan(0).WithMessage("Library User must be specified");

        RuleFor(l => l.LoanUpdateDto.LoanDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("Loan Date cannot be in the future");

        RuleFor(l => l.LoanUpdateDto.ReturnDate)
            .GreaterThanOrEqualTo(l => l.LoanUpdateDto.LoanDate).WithMessage("Return Date must be after Loan Date");

        RuleFor(l => l.LoanUpdateDto.FineAmount)
            .GreaterThanOrEqualTo(0).WithMessage("Fine Amount cannot be negative");
    }
}
