using Bookcrossing.Application.Logger;
using Bookcrossing.Application.Mapping;
using Bookcrossing.Application.Validators.Pipeline;
using FluentValidation;
using MassTransit;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bookcrossing.Application.Configuration
{
    public static class DependenciesConfiguration
    {
        public static void AddBookcrossingApplication(this IServiceCollection services)
        {
            services.RegisterMediator();
            services.RegisterMapping();
            services.RegisterFluentValidation();
            services.RegisterLogger();
            services.AddMassTransit();
        }

        private static void RegisterMediator(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        private static void RegisterFluentValidation(this IServiceCollection services)
        {
            AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PipelineValidationBehavior<,>));

            services.Scan(
                x =>
                {
                    var assemby = Assembly.GetExecutingAssembly();

                    x.FromAssemblies(assemby)
                        .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
                        .AsImplementedInterfaces()
                        .WithScopedLifetime();
                });
        }

        private static void RegisterMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(
                c => c.AddProfile<MappingConfiguration>(),
                typeof(MappingConfiguration));
        }

        private static void RegisterLogger(this IServiceCollection services)
        {
            services.AddScoped<ILoggerManager, LoggerManager>();
        }

        private static void AddMassTransit(this IServiceCollection services)
        {
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ReceiveEndpoint("event-listener", e =>
                    {
                    });
                });
            });

            services.AddMassTransitHostedService();
        }
    }
}
