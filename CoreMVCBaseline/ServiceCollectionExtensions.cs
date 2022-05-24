using CoreMVCBaseline.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreMVCBaseline
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CustomAppSettings>(configuration.GetSection("CustomSettings"));
            services.AddTransient<ICustomService, CustomService>();
            services.AddScoped<IProtectedCookies, ProtectedCookies>();

            return services;
        }
    }
}
