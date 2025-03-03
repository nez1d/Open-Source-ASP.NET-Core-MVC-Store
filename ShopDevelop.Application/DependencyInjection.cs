using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using ShopDevelop.Application.Data.Common.Mappings;
using ShopDevelop.Application.Entities.Product.Commands.Create;
using ShopDevelop.Application.Entities.Product.Commands.Delete;
using ShopDevelop.Application.Entities.Product.Commands.Update;
using ShopDevelop.Application.Entities.Product.Queries.GetAllProducts;
using ShopDevelop.Application.Entities.Product.Queries.GetProductDetails;

namespace ShopDevelop.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MappingProfile));

        services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
        
        services.AddMediatR(x =>
                x.RegisterServicesFromAssemblies(
                    typeof(CreateClothesProductCommand).Assembly,
                    typeof(UpdateProductCommand).Assembly,
                    typeof(DeleteProductCommand).Assembly,
                    typeof(GetProductDetailsQuery).Assembly,
                    typeof(GetProductListQuery).Assembly));

        services.AddMediatR(config => config.RegisterServicesFromAssembly(
            Assembly.GetExecutingAssembly()));
        
        return services;
    }
}