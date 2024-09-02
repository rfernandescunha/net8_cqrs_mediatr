using FluentValidation;
using Gertec.Api.Application.Handlers;
using MediatR;

namespace Gertec.Api.Configuration
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddCustomMediaR(this IServiceCollection services)
        {
            const string applicationAssemblyName = "Gertec.Api";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner.FindValidatorsInAssembly(assembly).ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationHandler<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingHandler<,>));

            services.AddMediatR(assembly);

            return services;
        }
    }
}