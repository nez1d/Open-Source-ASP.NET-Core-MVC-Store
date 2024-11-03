using ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace ShopDevelop.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(x =>
                x.RegisterServicesFromAssemblies(
                    typeof(GetMiniProductListQuery).Assembly));


        services.AddMediatR(config => config.RegisterServicesFromAssembly(
            Assembly.GetExecutingAssembly()));
        return services;
    }
}