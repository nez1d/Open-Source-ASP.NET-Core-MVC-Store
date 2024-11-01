using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ShopDevelop.Application.Data.Common.Mappings;
using ShopDevelop.Domain.Interfaces;
using System.Reflection;

namespace ShopDevelop.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssembly(
            Assembly.GetExecutingAssembly()));

        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(
                Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(
                typeof(IApplicationDbContext).Assembly));
        });
        return services;
    }
}