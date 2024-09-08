using Library.Application.Contracts.Persistence;
using Library.Application.Exceptions;
using Library.Application.Logging;
using MediatR;

namespace Library.Application.Features.Commands.Loan.Delete;

public class DeleteLoanHandler : IRequestHandler<DeleteLoanCommand, Unit>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IAppLogger<DeleteLoanHandler> _logger;

    public DeleteLoanHandler(
        ILoanRepository loanRepository,
        IAppLogger<DeleteLoanHandler> logger)
    {
        _loanRepository = loanRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
    {
        var loan = await _loanRepository.GetByIdAsync(request.LoanDeleteDto.Id);

        if (loan == null)
        {
            throw new NotFoundException(nameof(Loan), request.LoanDeleteDto.Id);
        }

        await _loanRepository.DeleteAsync(loan.Id);

        _logger.LogInformation($"Loan with ID {loan.Id} was deleted successfully.");

        return Unit.Value;
    }
}
