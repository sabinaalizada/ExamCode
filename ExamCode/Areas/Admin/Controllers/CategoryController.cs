using ExamCode.Data;
using ExamCode.Helpers;
using ExamCode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamCode.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Super Admin")]
    public class CategoryController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _env;

        public CategoryController(DataContext dataContext, IWebHostEnvironment env)
        {
            _dataContext = dataContext;
            _env = env;
        }
        public IActionResult Index(int page=1)
        {
            var query = _dataContext.Category.AsQueryable();

            var paginatedlist = PaginatedList<Category>.Create(query, 2, page);
            
            return View(paginatedlist);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category  category)
        {
            if (!ModelState.IsValid) return View();

           
            _dataContext.Category.Add(category);
            _dataContext.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {


            Category category = _dataContext.Category.FirstOrDefault(x => x.Id == id);

            if (category == null) return View();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Category  category)
        {

            if (!ModelState.IsValid) return View();

            Category Existcategory = _dataContext.Category.FirstOrDefault(x => x.Id == category.Id);

            if (Existcategory == null) return View();

            Existcategory.Name=category.Name;

            _dataContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {

            Category deletecategory = _dataContext.Category.FirstOrDefault(x => x.Id == id);

            if (deletecategory == null) return View();


            _dataContext.Category.Remove(deletecategory);

            _dataContext.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}
