using ExamCode.Areas.viewModels;
using ExamCode.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExamCode.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel adminLogin)
        {
            AppUser appUser=await _userManager.FindByNameAsync(adminLogin.Username);

            if(appUser == null)
            {
                ModelState.AddModelError("", "Password or username is incorrect");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, adminLogin.Password, false, false);


            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Password or username is incorrect");
                return View();
            }

            return RedirectToAction("Index", "dashboard");   
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("login", "account");
        }
    }
}
