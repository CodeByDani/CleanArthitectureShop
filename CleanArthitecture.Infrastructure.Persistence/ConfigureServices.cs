using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArthitecture.Infrastructure.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<DBContextConnection>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DBContextConnection")));
            return services;
        }
    }
}
