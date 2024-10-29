using Microsoft.Extensions.DependencyInjection;
using ProductSystem.Adapters.Adapters;
using ProductSystem.Adapters.Contracts;
using ProductSystem.Application.Adapters;
using ProductSystem.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Adapters
{
    public static class AdaptersServicesRegistration
    {
        public static IServiceCollection AddAdapterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IProductRepositoryAdapter, ProductRepositoryAdapter>();
            return services;
        }
    }
}
