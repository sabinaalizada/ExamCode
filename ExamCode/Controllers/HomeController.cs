using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExamCode.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            return View();
        }


       
    }
}