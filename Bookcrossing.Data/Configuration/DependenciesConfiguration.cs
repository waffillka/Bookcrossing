using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Repositories;
using Bookcrossing.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookcrossing.Data.Configuration
{
    public static class DependenciesConfiguration
    {
        public static IServiceCollection ConfigureSqlContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<BookcrossingDbContext>(opts =>
                opts.UseSqlServer(connectionString, b => b.MigrationsAssembly("Bookcrossing.Data")));

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IHistoryOfIssuingBooksRepository, HistoryOfIssuingBooksRepository>();

            return services;
        }
    }
}
