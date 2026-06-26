using AdenyaDapperProject.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;

namespace AdenyaDapperProject.Controllers
{
    [AdminControl]
    public class CategoryController : Controller
    {
        private readonly Context _context;

        public CategoryController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Listele<CategoryModel>("CategoryList");
            return View(values);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryModel category)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CategoryName", category.CategoryName);

            _context.Execute("CategoryAdd", param);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CategoryId", id);

            _context.Execute("CategoryDelete", param);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CategoryId", id);

            var value = _context.Getir<CategoryModel>("CategoryGetById", param);

            return View(value);
        }

        [HttpPost]
        public IActionResult Edit(CategoryModel category)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@CategoryId", category.CategoryId);
            param.Add("@CategoryName", category.CategoryName);

            _context.Execute("CategoryUpdate", param);

            return RedirectToAction("Index");
        }
    }
}