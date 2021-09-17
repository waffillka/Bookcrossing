using Bookcrossing.Application.Mapping;
using Bookcrossing.Application.Validators.Pipeline;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bookcrossing.Application.Configuration
{
    public static class DependenciesConfiguration
    {
        public static void BookcrossingApplication(this IServiceCollection services)
        {
            services.RegisterMediator();
            services.RegisterMapping();
            services.RegisterFluentValidation();
        }

        private static void RegisterMediator(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        private static void RegisterFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            AssemblyScanner.FindValidatorsInAssembly(Assembly.GetExecutingAssembly())
                .ForEach(item => services.AddScoped(item.InterfaceType, item.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(PipelineValidationBehavior<,>));

            services.Scan(
                x => {
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
    }
}
