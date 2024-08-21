using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Models;
using ShopDevelop.Data.Repository.Interfaces;
using System.Data.Entity;

namespace ShopDevelop.Data.Repository.Entity
{
    public class DbSessionsRepository : IDbSessionsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public DbSessionsRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        // Создание новой сессии.
        public async Task CreateSession(DbSession session)
        {
            var dbSession = await _applicationDbContext
                .Sessions.AddAsync(session);

            _applicationDbContext.SaveChangesAsync();     
        }
        //Получить сессию.
        public async Task<DbSession?> GetSession(Guid sessionId)
        {
            return await _applicationDbContext.Sessions
                .FirstOrDefaultAsync(i => i.DbSessionId == sessionId);
        }
        // Обновление сессии.
        public async Task UpdateSession(DbSession session)
        {
            var dbSession = await _applicationDbContext
                .Sessions.Where(i => i.DbSessionId == session.DbSessionId)
                .FirstOrDefaultAsync();

            dbSession.SessionData = session.SessionData;
            _applicationDbContext.SaveChangesAsync();
        }
        // Получение Id пользователя.
        public async Task<int?> GetUserId(DbSession dbSession)
        {
            var user = await _applicationDbContext.Sessions
                .Where(i => i.UserId == dbSession.UserId)
                .FirstOrDefaultAsync();

            return user.UserId;
        }

        public Task<int> SetUserId(int userId)
        {
            throw new NotImplementedException();
        }
        
        public Task<bool> IsLoggedIn()
        {
            throw new NotImplementedException();
        }
    }
}
