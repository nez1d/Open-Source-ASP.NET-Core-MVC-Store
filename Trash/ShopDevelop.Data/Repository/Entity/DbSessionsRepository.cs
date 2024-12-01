/*using Microsoft.AspNetCore.Http;
using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Entity.Auth;
using ShopDevelop.Data.Models;
using ShopDevelop.Data.Repository.Interfaces;
using System.Data.Entity;

namespace ShopDevelop.Data.Repository.Entity
{
    public class DbSessionsRepository : IDbSessionsRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DbSessionsRepository(
            ApplicationDbContext applicationDbContext,
            IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        private void CreateSessionCookie(Guid sessionId)
        {
            CookieOptions options = new CookieOptions();
            options.Path = "/";
            options.HttpOnly = true;
            options.Secure = true;

            _httpContextAccessor?.HttpContext.Response
                .Cookies.Delete(AuthConstants.SessionCookieName);

            _httpContextAccessor?.HttpContext.Response
                .Cookies.Append(AuthConstants.SessionCookieName, 
                sessionId.ToString(), options);
        }
        // Создание новой сессии.
        public async Task CreateSession(DbSession session)
        {
            var dbSession = await _applicationDbContext
                .Sessions.AddAsync(session);

            _applicationDbContext.SaveChangesAsync();     
        }
        //Получить сессию.
        public async Task<DbSession> GetSession()
        {
            *//*await _applicationDbContext.Sessions
                .FirstOrDefaultAsync(i => i.DbSessionId == sessionId);*//*

            Guid sessionId;

            var cookie = _httpContextAccessor?
                .HttpContext?.Request.Cookies?
                .FirstOrDefault(m => m.Key == 
                AuthConstants.SessionCookieName);

            if (cookie != null && cookie.Value.Value != null) 
            {
                sessionId = Guid.Parse(cookie.Value.Value); 
            }
            else
            {
                sessionId = Guid.NewGuid();
                CreateSessionCookie(sessionId);
                return await CreateSession();
            }

            var data = await GetSession(sessionId);
            if (data != null) 
            {
                data = await CreateSession();
                CreateSessionCookie(data.DbSesstionId);
            }
            return data;
        }
        //Получить сессию по sessionId.
        public async Task<DbSession?> GetSession(Guid sessionId)
        {     
            var cookie = _httpContextAccessor?
                .HttpContext?.Request.Cookies?
                .FirstOrDefault(m => m.Key == 
                AuthConstants.SessionCookieName);

            if (cookie != null && cookie.Value.Value != null)
            {
                sessionId = Guid.Parse(cookie.Value.Value);
            }
            else
            {
                sessionId = Guid.NewGuid();
                CreateSessionCookie(sesstionId);
                return await this.CreateSession();
            }

            var data = await this.GetSession(sessionId);
            if (data != null)
            {
                data = await this.CreateSession();
                CreateSessionCookie(data.DbSesstionId);
            }
            return data;
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
            *//*var user = await _applicationDbContext.Sessions
                .Where(i => i.UserId == dbSession.UserId)
                .FirstOrDefaultAsync();*//*

            var data = await GetSession();
            return data.UserId;
        }
        // TODO: переделать.
        public async Task<int> SetUserId(int userId)
        {
            var data = await GetSession();
            data.UserId = userId;
            data.DbSessionId = Guid.NewGuid();
            CreateSessionCookie(data.DbSessionId);
            await CreateSession(data);
        }
        
        public async Task<bool> IsLoggedIn()
        {
            var data = await GetSession();
            return data.UserId != null;
        }
    }
}
*/