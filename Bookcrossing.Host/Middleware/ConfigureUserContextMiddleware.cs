using Bookcrossing.Contracts.Context.TokenContext;
using Bookcrossing.Host.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bookcrossing.Host.Middleware
{
    public class ConfigureUserContextMiddleware
    {
        private readonly RequestDelegate _next;

        public ConfigureUserContextMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IClientUserContext clientUserContext)
        {
            CancellationToken cancellationToken = httpContext?.RequestAborted ?? CancellationToken.None;

            if (AuthorizationHelper.TryGetAuthorizationTokenFromHttpHeaders(httpContext, out string token))
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);

                var tokenS = jsonToken as JwtSecurityToken;

                
                clientUserContext.Name = tokenS.Claims?.FirstOrDefault(x => x.Type.Equals("name", StringComparison.OrdinalIgnoreCase))?.Value;
                clientUserContext.Email = tokenS.Claims?.FirstOrDefault(x => x.Type.Equals("email", StringComparison.OrdinalIgnoreCase))?.Value;
                clientUserContext.UserId = Guid.Parse(tokenS.Claims?.FirstOrDefault(x => x.Type.Equals("sub", StringComparison.OrdinalIgnoreCase))?.Value);
                clientUserContext.Role = tokenS.Claims?.FirstOrDefault(x => x.Type.Equals("role", StringComparison.OrdinalIgnoreCase))?.Value;
                clientUserContext.Phone = tokenS.Claims?.FirstOrDefault(x => x.Type.Equals("phone_number", StringComparison.OrdinalIgnoreCase))?.Value;
                clientUserContext.NickName = tokenS.Claims?.FirstOrDefault(x => x.Type.Equals("preferred_username", StringComparison.OrdinalIgnoreCase))?.Value;
             }

            await _next.Invoke(httpContext);
        }
    }
}