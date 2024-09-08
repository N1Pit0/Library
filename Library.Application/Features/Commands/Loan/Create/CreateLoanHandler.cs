using AutoMapper;
using FluentValidation;
using Library.Application.Contracts.Persistence;
using Library.Application.Logging;
using MediatR;

namespace Library.Application.Features.Commands.Loan.Create;

public class CreateLoanHandler : IRequestHandler<CreateLoanCommand, int>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IAppLogger<CreateLoanHandler> _logger;
    private readonly IMapper _mapper;

    public CreateLoanHandler(
        ILoanRepository loanRepository,
        IAppLogger<CreateLoanHandler> logger,
        IMapper mapper)
    {
        _loanRepository = loanRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateLoanValidator(_loanRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for CreateLoanCommand");
            throw new ValidationException(validationResult.Errors);
        }

        var loan = _mapper.Map<Domain.Loan>(request.LoanCreateDto);

        await _loanRepository.AddAsync(loan);

        _logger.LogInformation($"Loan with ID {loan.Id} was created successfully.");

        return loan.Id;
    }
}
