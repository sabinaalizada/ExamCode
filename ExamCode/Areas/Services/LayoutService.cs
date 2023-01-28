using ExamCode.Data;
using ExamCode.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ExamCode.Areas.Services
{
    public class LayoutService
    {
        private readonly UserManager<AppUser> _userManager;
        
        private readonly IHttpContextAccessor _httpContext;
        private readonly DataContext _dataContext;

        public LayoutService(UserManager<AppUser> userManager,IHttpContextAccessor httpContext,DataContext dataContext)
        {
            _userManager = userManager;
           
            _httpContext = httpContext;
            _dataContext = dataContext;
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
        public  async Task<List<Setting>> GetSetting()
        {
            return await _dataContext.Settings.ToListAsync();
        }

    }
}
