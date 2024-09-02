using FluentValidation;
using Gertec.Application.Handlers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Gertec.Infrastructure.BootStrap.Configuration
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddCustomMediaR(this IServiceCollection services)
        {
            const string applicationAssemblyName = "Gertec.Application";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner.FindValidatorsInAssembly(assembly).ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationHandler<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingHandler<,>));

            services.AddMediatR(assembly);

            return services;
        }
    }
}