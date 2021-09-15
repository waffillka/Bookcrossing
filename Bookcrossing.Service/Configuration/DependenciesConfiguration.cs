using Microsoft.Extensions.DependencyInjection;

namespace Bookcrossing.Application.Configuration
{
    public static class DependenciesConfiguration
    {
        public static void BookcrossingService(this IServiceCollection service)
        {
            service.RegisterMediator();
        }

        public static void RegisterMediator(this IServiceCollection service)
        {

        }
    }
}
