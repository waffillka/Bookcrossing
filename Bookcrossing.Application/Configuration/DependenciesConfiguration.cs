using Bookcrossing.Application.Mapping;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bookcrossing.Application.Configuration
{
    public static class DependenciesConfiguration
    {
        public static void BookcrossingService(this IServiceCollection services)
        {
            services.RegisterMediator();
            services.RegisterMapping();
        }

        private static void RegisterMediator(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        private static void RegisterMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(
                c => c.AddProfile<MappingConfiguration>(),
                typeof(MappingConfiguration));
        }
    }
}
