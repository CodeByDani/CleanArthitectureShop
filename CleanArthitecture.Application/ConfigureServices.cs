using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CleanArthitecture.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            return services;
        }
    }
}
