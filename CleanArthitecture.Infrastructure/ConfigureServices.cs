using CleanArthitecture.Application.Common.Interfaces.Authentication;
using CleanArthitecture.Application.Common.Interfaces.Services;
using CleanArthitecture.Infrastructure.Authentication;
using CleanArthitecture.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CleanArthitecture.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }
        public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSetting = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSetting);
            services.AddSingleton(Options.Create(jwtSetting));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = jwtSetting.Isuuer,
                     ValidAudience = jwtSetting.Audience,
                     IssuerSigningKey = new SymmetricSecurityKey(
                          Encoding.UTF8.GetBytes(jwtSetting.Secret))
                 };
                 options.SaveToken = true;
             });
            return services;

        }
    }
}
