namespace easywallet_api.Middlewares;

using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using easywallet_api.Helpers;
using Microsoft.AspNetCore.Http;

class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null && JWT.ValidateToken(token))
        {
            // Token is valid, proceed to the next middleware
            await _next(context);
        }
        else
        {
            // Token is invalid or missing, return 401 Unauthorized
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Unauthorized");
        }
    }
}