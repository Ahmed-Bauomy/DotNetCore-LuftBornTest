using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProductSystem.Application.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnHandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            return services;
        }
    }
}
