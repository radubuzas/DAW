using WebApplication1.Helpers.JwtUtils;
using WebApplication1.Services;

namespace WebApplication1.Helpers.Middleware
{

    public class JwtMiddleware
    {
        private readonly RequestDelegate _nextRequestDelegate;

        public JwtMiddleware(RequestDelegate nextRequestDelegate)
        {
            _nextRequestDelegate = nextRequestDelegate;
        }

        public async Task Invoke(HttpContext httpContext, IUtilizatorService utilizatorService, IJwtUtils jwtUtils)
        {
            var token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var userId = jwtUtils.ValidateJwtToken(token);

            if (userId != -1)
            {
                httpContext.Items["Utilizator"] = utilizatorService.GetById(userId);
            }

            await _nextRequestDelegate(httpContext);
        }

    }
}