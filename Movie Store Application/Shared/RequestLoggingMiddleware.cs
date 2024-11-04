using Microsoft.Identity.Client;
using System.Diagnostics;

namespace Movie_Store_Application.Shared
{
    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;
        public SecurityHeadersMiddleware(RequestDelegate next) 
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context) 
        {

            context.Response.Headers.Add("Strict-Transport-Security", "max-age=31536000; includeSubDomains; preload");
            //context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; script-src 'self'");
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Add("X-Frame-Options", "DENY");
            context.Response.Headers.Add("Referrer-Policy", "no-referrer");
            context.Response.Headers.Add("Permissions-Policy", "geolocation=(), camera=(), microphone=()");
            context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
            context.Response.Headers.Add("Cache-Control", "no-store, no-cache, must-revalidate");
            context.Response.Headers.Add("Pragma", "no-cache");
            // Call the next middleware in the pipeline
            await _next(context);

        }
    }
}
