using System;
using BankApplication.Application.Authentication;
using Microsoft.Extensions.DependencyInjection;
namespace BankApplication.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}

