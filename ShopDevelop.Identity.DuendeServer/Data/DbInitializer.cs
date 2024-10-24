namespace ShopDevelop.Identity.DuendeServer.Data;

public class DbInitializer
{
    public static void Initialize(AuthDbContext context) =>
        context.Database.EnsureCreated();
}