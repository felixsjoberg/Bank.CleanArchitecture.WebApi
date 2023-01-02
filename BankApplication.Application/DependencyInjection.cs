using System.Reflection;
using BankApplication.Application.Customers.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
namespace BankApplication.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);
        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}

