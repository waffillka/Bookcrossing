using Microsoft.AspNetCore.Http;

namespace Bookcrossing.Host.Helpers
{
    public static class AuthorizationHelper
    {
        public static bool TryGetAuthorizationTokenFromHttpHeaders(HttpContext httpContext, out string token)
        {
            token = httpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
            if (string.IsNullOrEmpty(token) || token == "null")
            {
                return false;
            }

            return true;
        }
    }
}
