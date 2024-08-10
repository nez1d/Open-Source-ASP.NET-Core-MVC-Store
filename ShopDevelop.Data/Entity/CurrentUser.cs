using Microsoft.AspNetCore.Http;

namespace ShopDevelop.Data.Entity
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }

        public bool IsLoggedIn()
        {
            return _contextAccessor.HttpContext?.Session.GetInt32(AuthConstants.AUTH_SESSION_PARAM_NAME) != null;

        }
    }
}
