using CleanArthitecture.Presentation.Common.Error;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CleanArthitecture.Presentation
{
    public static class ConfigureServices
    {
        public static IServiceCollection RegisterPresentationServices(this IServiceCollection services)
        {
            //todo services.AddSingleton<ProblemDetailsFactory,ProblemCustomeDetailsFactory>();
            services.AddHttpContextAccessor();
            return services;
        }
    }
}
