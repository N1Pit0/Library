using AutoMapper;
using FluentValidation;
using Library.Application.Contracts.Email;
using Library.Application.Contracts.Persistence;
using Library.Application.Logging;
using Library.Application.Models.Email;
using MediatR;

namespace Library.Application.Features.Commands.Loan.Create;

public class CreateLoanHandler : IRequestHandler<CreateLoanCommand, int>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IAppLogger<CreateLoanHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IEmailSender _emailSender;

    public CreateLoanHandler(
        ILoanRepository loanRepository,
        IAppLogger<CreateLoanHandler> logger,
        IEmailSender emailSender,
        IMapper mapper)
    {
        _loanRepository = loanRepository;
        _logger = logger;
        _mapper = mapper;
        _emailSender = emailSender;
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
        
        // Send loan confirmation email
        var emailMessage = new EmailMessage
        {
            To = loan.User.Email,  // User's email from the Loan entity
            Subject = "Loan Confirmation",
            Body = $"Your loan for the book '{loan.Book.Title}' has been created. Please return it by {loan.ReturnDate:yyyy-MM-dd}."
        };

        _logger.LogInformation($"Loan with ID {loan.Id} was created successfully.");

        await _emailSender.SendEmail(emailMessage);
        
        return loan.Id;
    }
}
