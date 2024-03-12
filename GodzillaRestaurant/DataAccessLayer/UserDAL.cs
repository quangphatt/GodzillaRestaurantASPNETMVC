using GodzillaRestaurant.Services;
using System.Security.Claims;

namespace GodzillaRestaurant.DataAccessLayer
{
    public class UserDAL : IUserService
    {
        private readonly HttpContext _httpContext;

        public UserDAL(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public string GetUserId() => _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
    }
}
