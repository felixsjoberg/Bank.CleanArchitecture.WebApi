using System;
using BankApplication.Application.Authentication;
using BankApplication.Application.Authentication.Commands;
using BankApplication.Application.Authentication.Queries;
using Microsoft.Extensions.DependencyInjection;
namespace BankApplication.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

        return services;
    }
}

