using Core.Entities;
using Core.Interfaces.Mappers;
using Core.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Mappers.MappersConfig
{
    public static class MappersConfig
    {
        public static void ConfigureMappers(this IServiceCollection services)
        {
            services.AddScoped<IMapper<Feedback, CreateFeedbackViewModel>, CreateFeedbackMapper>();
        }
    }
}
