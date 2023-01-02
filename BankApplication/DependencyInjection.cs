
using BankApplication.Api.Common.Mapping;
using MediatR;

namespace BankApplication.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation (this IServiceCollection services)
    {
        services.AddControllers();
        services.AddMappings();
        return services;
    }
}

