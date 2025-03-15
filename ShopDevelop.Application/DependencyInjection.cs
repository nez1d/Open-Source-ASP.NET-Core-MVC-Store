using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using ShopDevelop.Application.Data.Common.Mappings;
using ShopDevelop.Application.Entities.Category.Commands.Create;
using ShopDevelop.Application.Entities.Product.Commands.Create;
using ShopDevelop.Application.Entities.Product.Commands.Create.Clothes;
using ShopDevelop.Application.Entities.Product.Commands.Create.Shoes;
using ShopDevelop.Application.Entities.Product.Commands.Delete;
using ShopDevelop.Application.Entities.Product.Commands.Update;
using ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;
using ShopDevelop.Application.Entities.Product.Queries.GetProduct;
using ShopDevelop.Application.Entities.Product.Queries.GetProductDetails;

namespace ShopDevelop.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        // Product
        services.AddAutoMapper(typeof(CreateClothesProductMappingProfile));
        services.AddAutoMapper(typeof(CreateShoesProducMappingProfile));
        services.AddAutoMapper(typeof(UpdateProductMappingProfile));
        services.AddAutoMapper(typeof(GetProductMappingProfile));
        // Category
        services.AddAutoMapper(typeof(CreateCategoryMappingModel));
        
        services.AddValidatorsFromAssemblies([Assembly.GetExecutingAssembly()]);
        
        // Product
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(CreateClothesProductCommand).Assembly,
                typeof(CreateShoesProductCommand).Assembly,
                typeof(UpdateProductCommand).Assembly,
                typeof(DeleteProductCommand).Assembly,
                typeof(GetProductQuery).Assembly,
                typeof(GetMiniProductListQuery).Assembly));
        // Category
        services.AddMediatR(x =>
            x.RegisterServicesFromAssemblies(
                typeof(CreateCategoryCommand).Assembly,
                typeof(DeleteProductCommand).Assembly,
                typeof(DeleteProductCommand).Assembly));

        services.AddMediatR(config => config.RegisterServicesFromAssembly(
            Assembly.GetExecutingAssembly()));
        
        return services;
    }
}