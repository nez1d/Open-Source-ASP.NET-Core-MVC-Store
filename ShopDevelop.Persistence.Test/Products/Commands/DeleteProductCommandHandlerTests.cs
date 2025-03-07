/*using System.Data.Entity;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Entities.Product.Commands.Create;
using ShopDevelop.Application.Entities.Product.Commands.Delete;
using ShopDevelop.Persistence.Entities.Product.Command.Create;
using ShopDevelop.Persistence.Entities.Product.Command.Delete;
using ShopDevelop.Persistence.Test.Common;

namespace ShopDevelop.Persistence.Test.Products.Commands;

public class DeleteProductCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task DeleteProductCommandHandlerTest_Success()
    {
        // Arrange
        var handler = new DeleteProductCommandHandler(context);

        // Act
        await handler.Handle(new DeleteProductCommand
        {
            ProductId = ProductContextFactory.ProductIdForDelete,
            UserId = ProductContextFactory.UserIdA
        },
        CancellationToken.None);
        
        // Assert
        Assert.Null(context.Products.SingleOrDefault(product =>
            product.Id == ProductContextFactory.ProductIdForDelete));
    }

    [Fact]
    public async Task DeleteProductCommandHandlerTest_FailOnWrongId()
    {
        // Arrange
        var handler = new DeleteProductCommandHandler(context);
        
        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new DeleteProductCommand
                {
                    ProductId = Guid.NewGuid(),
                    UserId = ProductContextFactory.UserIdA
                }, 
                CancellationToken.None));
    }

    [Fact]
    public async Task DeleteProductCommandHandlerTest_FailOnWrongUserId()
    {
        // Arrange
        var deleteHandler = new DeleteProductCommandHandler(context);
        var createHandler = new CreateProductCommandHandler(context);
        var productId = await createHandler.Handle(
            new CreateClothesProductCommand
            {
                ProductName = "",
                Description = "",
            }, 
            CancellationToken.None);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await deleteHandler.Handle(
                new DeleteProductCommand
                {
                    ProductId = productId,
                    UserId = ProductContextFactory.UserIdB
                }, 
                CancellationToken.None));
    }
}*/