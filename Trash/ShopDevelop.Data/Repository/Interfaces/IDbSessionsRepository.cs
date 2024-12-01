using ShopDevelop.Data.Models;

namespace ShopDevelop.Data.Repository.Interfaces
{
    public interface IDbSessionsRepository
    {
        Task CreateSession(DbSession session);
        Task<DbSession?> GetSession(Guid sessionId);
        Task<DbSession?> GetSession();
        Task UpdateSession(DbSession session);
        Task<int> SetUserId(int userId);
        Task<int?> GetUserId(DbSession dbSession); 
        Task<bool> IsLoggedIn();
    }
}
