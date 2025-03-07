namespace ShopDevelop.Persistence.Test.Common;

public abstract class TestCommandBase : IDisposable
{
    protected readonly ApplicationDbContext context;

    public TestCommandBase()
    {
        this.context = ProductContextFactory.Create();
    }

    public void Dispose()
    {
        ProductContextFactory.Destroy(this.context);
    }
}