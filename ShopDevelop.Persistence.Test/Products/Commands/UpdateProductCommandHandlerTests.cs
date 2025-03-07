/*using Microsoft.EntityFrameworkCore;
using ShopDevelop.Application.Data.Common.Exceptions;
using ShopDevelop.Application.Entities.Product.Commands.Update;
using ShopDevelop.Persistence.Entities.Product.Command.Update;
using ShopDevelop.Persistence.Test.Common;

namespace ShopDevelop.Persistence.Test.Products.Commands;

public class UpdateProductCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task UpdateNoteCommandHandler_Success()
    {
        // Arrange
        var handler = new UpdateProductCommandHandler(context);
        var updatedName = "";
            
        // Act
        await handler.Handle(new UpdateProductCommand
        {
            Id = ProductContextFactory.ProductIdForUpdate,
            ProductName = updatedName
            ProductName = updatedName
        }, CancellationToken.None);
        // Assert
        Assert.NotNull(await context.Products.SingleOrDefaultAsync(product =>
            product.Id == ProductContextFactory.ProductIdForUpdate &&
            product.ProductName == updatedName));
    }

    [Fact]
    public async Task UpdateProductCommandHandler_FailOnWrongId()
    {
        // Arrange
        var handler = new UpdateProductCommandHandler(context);
        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateProductCommand
                {
                    Id = Guid.NewGuid()
                }, CancellationToken.None));
    }

    [Fact]
    public async Task UpdateProductCommandHandler_FailOnWrongUserId()
    {
        
    }
}*/