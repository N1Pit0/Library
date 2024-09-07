using MediatR;

namespace Library.Application.Features.Commands.Loan.Create;

public class CreateLoanHandler:
    IRequestHandler<CreateLoanCommand, int>
{
    public Task<int> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}