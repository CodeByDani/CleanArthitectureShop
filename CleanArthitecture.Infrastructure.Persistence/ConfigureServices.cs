using CleanArthitecture.Application.Common.Interfaces;
using CleanArthitecture.Domain.Repositories;
using CleanArthitecture.Infrastructure.Persistence.Common.Repository;
using CleanArthitecture.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArthitecture.Infrastructure.Persistence
{
    public static class ConfigureServices
    {
        public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();


            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<DBContextConnection>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DBContextConnection")));
            return services;
        }
    }
}
