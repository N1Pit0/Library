using Library.Application.Contracts.Email;
using Library.Application.Logging;
using Library.Application.Models.Email;
using Library.Infrastructure.EmailService;
using Library.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        serviceCollection.AddTransient<IEmailSender, EmailSender>();
        serviceCollection.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        
        return serviceCollection;
    }
}
