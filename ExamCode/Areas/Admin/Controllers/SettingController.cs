using ExamCode.Data;
using ExamCode.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExamCode.Areas.Admin.Controllers
{
    public class SettingController : Controller
    {
        private readonly DataContext _dataContext;

        public SettingController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            List<Setting> settings =_dataContext.Settings.ToList();
            return View(settings);
        }

        public IActionResult Update(int id)
        {


            Setting setting = _dataContext.Settings.FirstOrDefault(x => x.Id == id);

            if (setting == null) return View();

            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Setting setting)
        {

            if (!ModelState.IsValid) return View();

            Setting Existsetting = _dataContext.Settings.FirstOrDefault(x => x.Id == setting.Id);
            
            if (Existsetting == null) return View();

            Existsetting.Value = setting.Value;

            _dataContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
