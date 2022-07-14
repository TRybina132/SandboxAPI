using Core.Interfaces.Repository;
using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Config
{
    public static class ConfigureRepositories
    {
        public static void AddApplicationRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
        }
    }
}
