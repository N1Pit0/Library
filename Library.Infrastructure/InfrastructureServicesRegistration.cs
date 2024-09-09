using Library.Application.Contracts.Email;
using Library.Application.Logging;
using Library.Application.Models.Email;
using Library.Infrastructure.EmailService;
using Library.Infrastructure.EmailService.LoanManagement;
using Library.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        services.AddHostedService<LoanReminderService>();
        
        return services;
    }
}
