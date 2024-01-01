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
            var jwtSetting = new JwtSettings();
            configuration.Bind(JwtSettings.SectionName, jwtSetting);
            services.AddSingleton(Options.Create(jwtSetting));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSetting.Issuer,
                    ValidAudience = jwtSetting.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSetting.Secret))
                });


            return services;
        }
    }
}
