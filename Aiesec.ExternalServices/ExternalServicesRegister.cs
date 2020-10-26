using Aiesec.ExternalServices.Mail;
using Microsoft.Extensions.DependencyInjection;

namespace Aiesec.ExternalServices
{
    public static class ExternalServicesRegister
    {
        public static IServiceCollection AddExternalServices(this IServiceCollection services)
        {
            services.AddScoped<IMailService, MailService>();

            return services;
        }
    }
}