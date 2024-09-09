using Library.Application.Contracts.Email;
using Library.Application.Contracts.Persistence;
using Library.Application.Logging;
using Library.Application.Models.Email;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Library.Infrastructure.EmailService.LoanManagement;

public class LoanReminderService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public LoanReminderService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var loanRepository = scope.ServiceProvider.GetRequiredService<ILoanRepository>();
                var emailSender = scope.ServiceProvider.GetRequiredService<IEmailSender>();

                // Check for loans due in 3 days
                var loansDueSoon = await loanRepository.GetLoansDueInDaysAsync(3);

                foreach (var loan in loansDueSoon)
                {
                    var emailMessage = new EmailMessage
                    {
                        To = loan.User.Email,  // User's email from the Loan entity
                        Subject = "Loan Due Date Reminder",
                        Body = $"Dear {loan.User.FirstName} {loan.User.LastName},\n\n" +
                               $"This is a reminder that your loan for the book '{loan.Book.Title}' is due on {loan.ReturnDate:yyyy-MM-dd}.\n" +
                               "Please ensure that the book is returned by the due date to avoid any late fees.\n\n" +
                               "Thank you for using our library service!\n\n" +
                               "Best regards,\n" +
                               "Your Library Team"
                    };

                    await emailSender.SendEmail(emailMessage);
                }
            }

            // Wait before checking again (e.g., run once per day)
            await Task.Delay(TimeSpan.FromDays(1), stoppingToken);
        }
    }
}
