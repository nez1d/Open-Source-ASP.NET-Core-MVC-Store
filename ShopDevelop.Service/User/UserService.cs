/*using ShopDevelop.Data.DataBase;

namespace ShopDevelop.Service.User
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public User FindByEmail(string email)
        {
            var users = _context.User.Where(x => x.Email == email);
            return users.FirstOrDefault();
        }
    }
}
*/