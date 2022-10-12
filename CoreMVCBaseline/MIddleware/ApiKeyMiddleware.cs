using CoreMVCBaseline.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCBaseline.MIddleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;        
        public ApiKeyMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var apiKeyConfiguration = new ApiKeyConfiguration();
            var configuration = context.RequestServices.GetRequiredService<IConfiguration>();
            configuration.Bind(nameof(ApiKeyConfiguration), apiKeyConfiguration);
            

            if (!context.Request.Headers.TryGetValue(apiKeyConfiguration.ApiHeader, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided ");
                return;
            }
            

            if (!apiKeyConfiguration.XApiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }

            await _next(context);
        }
    }
}
