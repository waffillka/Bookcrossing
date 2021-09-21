using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookcrossing.Data.Configuration
{
    public static class DependenciesConfiguration
    {
        public static void AddBookcrossingData(this IServiceCollection services, string connectionString)
        {
            services.ConfigureDbContext(connectionString);
            services.RegisterRepositories();
        }

        private static void ConfigureDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BookcrossingDbContext>(opts =>
                opts.UseLazyLoadingProxies()
                .UseSqlServer(connectionString, b => b.MigrationsAssembly("Bookcrossing.Data")));
        }

        private static void RegisterRepositories(this IServiceCollection services)
        {
            var currentAssembly = typeof(DependenciesConfiguration);

            services.Scan(scan => scan.FromAssembliesOf(currentAssembly)
                                      .AddClasses(classes => classes.AssignableTo(typeof(IRepositoryBase<>)))
                                      .AsImplementedInterfaces()
                                      .WithTransientLifetime()
                         );
        }
    }
}
