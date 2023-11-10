
using BankApplication.Api.Common.Mapping;
using BankApplication.Api.Service;
using MediatR;

namespace BankApplication.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation (this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddTransient<JwtService>();
        return services;
    }
}

