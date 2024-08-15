using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Models;
using ShopDevelop.Data.Repository.Interfaces;

namespace ShopDevelop.Data.Repository.Entity
{
    public class DbSessionsRepository : IDbSessionsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DbSessionsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        // TODO: ДОДЕЛАТЬ РЕАЛИЗАЦИЮ ИНТЕРФЕЙСА.
        public async Task CreateSession(DbSession session)
        {
            var dbSession = await _applicationDbContext.Sessions.AddAsync(session);
            _applicationDbContext.SaveChangesAsync();     
        }

        public async Task<DbSession?> GetSession(Guid sessionId)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateSession(DbSession session)
        {
            throw new NotImplementedException();
        }

        public Task<int?> GetUserId()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsLoggedIn()
        {
            throw new NotImplementedException();
        }

        public Task<int> SetUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
