/*using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Entities.Product.Commands.Create;
using ShopDevelop.Persistence.Test.Common;
using ShopDevelop.Persistence.Entities.Product.Command.Create;

namespace ShopDevelop.Persistence.Test.Products.Commands;

public class CreateProductCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CreateProductCommandHandler_Tests()
    {
        // Arrange
        var handler = new CreateProductCommandHandler(context);
        var productName = "";
        var description = "";
        
        // Act
        var productId = await handler.Handle(new CreateClothesProductCommand
        {
            ProductName = productName,
        }, 
        CancellationToken.None);
        
        // Assert
        Assert.NotNull(
            await context.Products.SingleOrDefaultAsync(product => 
                product.Id == productId && product.ProductName == productName &&
                product.Description == description));
    }
}*/