using ExamCode.Models;
using Microsoft.AspNetCore.Identity;

namespace ExamCode.Areas.Services
{
    public class LayoutService
    {
        private readonly UserManager<AppUser> _userManager;
        
        private readonly IHttpContextAccessor _httpContext;

        public LayoutService(UserManager<AppUser> userManager,IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
           
            _httpContext = httpContext;
        }

        public async Task<AppUser> GetUser()
        {
            AppUser appUser = null;
            if (_httpContext.HttpContext.User.Identity.IsAuthenticated)
            {
                appUser = await _userManager.FindByNameAsync(_httpContext.HttpContext.User.Identity.Name);
                return appUser;
            }
            return null;
        }

    }
}
