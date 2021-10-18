using Microsoft.AspNetCore.Builder;

namespace Bookcrossing.Host.Middleware
{
    public static class RegisterCustomMiddleware
    {
        public static void RegisteMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ConfigureUserContextMiddleware>();
        }
    }
}
