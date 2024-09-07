using MediatR;

namespace Library.Application.Features.Commands.Loan.Update;

public class UpdateLoanHandler:
    IRequestHandler<UpdateLoanCommand, Unit>
{
    public Task<Unit> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}