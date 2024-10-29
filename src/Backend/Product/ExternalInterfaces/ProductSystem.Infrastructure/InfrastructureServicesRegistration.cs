using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductSystem.Adapters.Contracts;
using ProductSystem.Domain.Contracts;
using ProductSystem.Infrastructure.Data;
using ProductSystem.Infrastructure.Mail;
using ProductSystem.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ProductContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ProductsConnectionString"));
            });
            services.AddScoped<IMailServiceAdapter, InFraMailService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
