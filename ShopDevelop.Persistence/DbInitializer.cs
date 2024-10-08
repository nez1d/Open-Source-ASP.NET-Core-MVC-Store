namespace ShopDevelop.Persistence
{
    public class DbInitializer
    {
        public static void Initializer(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}