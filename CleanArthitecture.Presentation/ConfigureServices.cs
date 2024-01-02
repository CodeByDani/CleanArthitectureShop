using Mapster;
using MapsterMapper;
using System.Reflection;

namespace CleanArthitecture.Presentation
{
    public static class ConfigureServices
    {
        public static IServiceCollection RegisterPresentationServices(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();
            //todo services.AddSingleton<ProblemDetailsFactory,ProblemCustomeDetailsFactory>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
