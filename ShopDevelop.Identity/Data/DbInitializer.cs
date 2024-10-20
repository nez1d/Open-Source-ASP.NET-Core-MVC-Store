namespace ShopDevelop.Identity.Data
{
    public class DbInitializer 
    {
        public static void Initialize(AuthDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
