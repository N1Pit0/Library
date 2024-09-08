using AutoMapper;
using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.Exceptions;
using Library.Application.Logging;
using MediatR;

namespace Library.Application.Features.Commands.Loan.Update;

public class UpdateLoanHandler : IRequestHandler<UpdateLoanCommand, Unit>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IAppLogger<UpdateLoanHandler> _logger;
    private readonly IMapper _mapper;

    public UpdateLoanHandler(
        ILoanRepository loanRepository,
        IAppLogger<UpdateLoanHandler> logger,
        IMapper mapper)
    {
        _loanRepository = loanRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLoanCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLoanValidator(_loanRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for UpdateLoanCommand");
            throw new ValidationException(validationResult.Errors);
        }

        var loan = await _loanRepository.GetByIdAsync(request.LoanUpdateDto.Id);

        if (loan == null)
        {
            throw new NotFoundException(nameof(Loan), request.LoanUpdateDto.Id);
        }

        _mapper.Map(request.LoanUpdateDto, loan);

        await _loanRepository.UpdateAsync(loan);

        _logger.LogInformation($"Loan with ID {loan.Id} was updated successfully.");

        return Unit.Value;
    }
}
