using CleanArthitecture.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArthitecture.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationServices, AuthenticationServices>();
            return services;
        }
    }
}
