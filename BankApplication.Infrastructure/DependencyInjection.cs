
using BankApplication.Application.Common.Interfaces;
using BankApplication.Application.Common.Interfaces.Services;
using BankApplication.Infrastructure.Authentication;
using BankApplication.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using BankApplication.Infrastructure.Presistence;
using BankApplication.Application.Persistence;

namespace BankApplication.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}

