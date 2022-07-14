using Application.Config;
using DataAccess.Config;

namespace SandboxAPI.Configuration
{
    public static class ServicesConfig
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddApplicationServices();
            services.AddApplicationRepositories();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(name: AllowedOrigins,
            //    policy =>
            //    {
            //        policy.WithOrigins("http://localhost:4200");
            //        policy.WithHeaders("*");
            //        policy.WithMethods("*");
            //        policy.WithExposedHeaders("X-Pagination");
            //    });
            //});
        }
    }
}
