using Application.Services;
using Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Config
{
    public static class CustomServicesConfig
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IEmailService, EmailService>();
        }
    }
}
