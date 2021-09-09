using Bookcrossing.Data.DbContext;
using Bookcrossing.Data.Repositories;
using Bookcrossing.Data.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bookcrossing.Data.Configuration
{
    public static class DependenciesConfiguration
    {
        //public static IServiceCollection ConfigureIdentity(this IServiceCollection service)
        //{
        //    var builder = service.AddIdentityCore<User>(options =>
        //    {
        //        options.Password.RequireDigit = true;
        //        options.Password.RequireUppercase = true;
        //        options.Password.RequiredLength = 6;
        //        options.Password.RequireLowercase = true;
        //        options.Password.RequireNonAlphanumeric = false;

        //        options.User.RequireUniqueEmail = true;
        //    });

        //    builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), builder.Services);
        //    builder.AddEntityFrameworkStores<BookcrossingDbContext>().AddDefaultTokenProviders();

        //    return service;
        //}

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
