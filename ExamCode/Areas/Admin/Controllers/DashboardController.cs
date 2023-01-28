using ExamCode.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamCode.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DashboardController(UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateAdmin()
        {
            AppUser appUser = new AppUser
            {
                UserName="Sabina",
                FullName="Sabina Alizada"
                
            };

            var result=await _userManager.CreateAsync(appUser,"Admin123");

            return Ok(result);
        }


        public async Task<IActionResult> CreateRole()
        {
            IdentityRole identityRole1 = new IdentityRole("Super Admin");
            IdentityRole identityRole2 = new IdentityRole("Admin");
            IdentityRole identityRole3 = new IdentityRole("Member");

            await _roleManager.CreateAsync(identityRole1);
            await _roleManager.CreateAsync(identityRole2);
            await _roleManager.CreateAsync(identityRole3);

            return Ok("Created");
        }

        public async Task<IActionResult> AddRole()
        {
            AppUser appUser = await _userManager.FindByNameAsync("Sabina");

            await _userManager.AddToRoleAsync(appUser, "Super Admin");

            return Ok("Role Added");
        }
    }
}
