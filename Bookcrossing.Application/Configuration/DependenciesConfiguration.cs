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
        }

        private static void RegisterMediator(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
