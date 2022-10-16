using Microsoft.AspNetCore.Mvc;
using test_mvc.Models;
using test_mvc.Services;
 
namespace test_mvc.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
 
        public IActionResult Index()
        {
            var categories = _categoryService.GetCategories();
            return View(categories);
        }

        public IActionResult Create()
        {
            var categories = _categoryService.GetCategories();
            return View(categories);
        }
        public IActionResult Save(Category category)
        {
            if(category.Id == 0)
            {
                _categoryService.CreateCategory(category);
            }
            else{
                _categoryService.UpdateCategory(category);
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult Update(int Id)
        {
            var category = _categoryService.GetCategoryByID(Id);
            if(category == null)
                return RedirectToAction("Create");
            var categories = _categoryService.GetCategories();
            ViewBag.Category = category;
            return View(categories);
        }

        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }

    }
}