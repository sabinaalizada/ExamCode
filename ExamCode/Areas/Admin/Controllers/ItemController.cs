using ExamCode.Data;
using ExamCode.Helpers;
using ExamCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamCode.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _env;

        public ItemController(DataContext dataContext,IWebHostEnvironment env)
        {
            _dataContext = dataContext;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Item> Items=_dataContext.Items.Include(x=>x.Category).ToList();
            return View(Items);
        }
        public IActionResult Create()
        {
            ViewBag.Category=_dataContext.Category.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            ViewBag.Category = _dataContext.Category.ToList();
            if (!ModelState.IsValid) return View();

            if (item.formFile is null)
            {
                ModelState.AddModelError("", "File is needed");
                return View();
            }

            if (item.formFile is not null)
            {
                if(item.formFile.ContentType!="image/jpeg" && item.formFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("", "Type of File is not correct");
                    return View();
                }
                if(item.formFile.Length > 2097152)
                {
                    ModelState.AddModelError("", "Size of File is not correct");
                    return View();
                }

                item.ImageUrl = item.formFile.SaveFile(_env.WebRootPath, "uploads/items");
            }

            _dataContext.Items.Add(item);
            _dataContext.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            ViewBag.Category = _dataContext.Category.ToList();

            Item item = _dataContext.Items.FirstOrDefault(x => x.Id == id);

            if(item==null) return View();

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Item item)
        {
            ViewBag.Category = _dataContext.Category.ToList();

            if (!ModelState.IsValid) return View();
            

            Item Existitem = _dataContext.Items.FirstOrDefault(x => x.Id ==item.Id);

            if(Existitem==null) return View();

            

            if (item.formFile is not null)
            {
                if (item.formFile.ContentType != "image/jpeg" && item.formFile.ContentType != "image/png")
                {
                    ModelState.AddModelError("", "Type of File is not correct");
                    return View();
                }
                if (item.formFile.Length > 2097152)
                {
                    ModelState.AddModelError("", "Size of File is not correct");
                    return View();
                }

                FileManager.Delete(_env.WebRootPath, "uploads/items", Existitem.ImageUrl);

                Existitem.ImageUrl = item.formFile.SaveFile(_env.WebRootPath, "uploads/items");
            }
            Existitem.Desc = item.Desc;
            Existitem.CategoryId = item.CategoryId;

            _dataContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            ViewBag.Category = _dataContext.Category.ToList();

            Item deleteitem = _dataContext.Items.FirstOrDefault(x => x.Id == id);

            if (deleteitem == null) return View();

            FileManager.Delete(_env.WebRootPath, "uploads/items", deleteitem.ImageUrl);

            _dataContext.Items.Remove(deleteitem);

            _dataContext.SaveChanges();

            return RedirectToAction(nameof(Index));

        }



    }
}
