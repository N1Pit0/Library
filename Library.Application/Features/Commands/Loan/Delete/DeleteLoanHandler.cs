using MediatR;

namespace Library.Application.Features.Commands.Loan.Delete;

public class DeleteLoanHandler:
    IRequestHandler<DeleteLoanCommand, Unit>
{
    public Task<Unit> Handle(DeleteLoanCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}