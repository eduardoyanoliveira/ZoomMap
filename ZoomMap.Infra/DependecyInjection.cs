using ZoomMap.Infra.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ZoomMap.Application.Interfaces.Authentication;
using ZoomMap.Application.Interfaces.Data;
using ZoomMap.Application.Interfaces.Services;
using ZoomMap.Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ZoomMap.Infra.InMemoryRepositories;
using ZoomMap.Application.Interfaces.Events;
using ZoomMap.Infra.Events;

namespace ZoomMap.Infra;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configuration
    )
    {

        services.AddAuth(configuration);

        services.AddScoped<IMessageBroker, MessageBroker>();
        services.AddScoped<IEventHandlersService, EventHandlersService>();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, InMemoryUserRepository>();
        services.AddScoped<IProductRepository, InMemoryProductRepository>();
        services.AddScoped<IServiceRepository, InMemoryServiceRepository>();

        return services;
    }

    public static IServiceCollection AddAuth(
       this IServiceCollection services,
       ConfigurationManager configuration
    )
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret))
            });

        return services;
    }

}