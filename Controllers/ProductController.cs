using Microsoft.AspNetCore.Mvc;
using test_mvc.Models;
using test_mvc.Services;
 
namespace test_mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
 
        public IActionResult Index(string searchName, int CategoryId)
        {
            @ViewData["ProductName"] = searchName;
            @ViewData["CategoryId"] = CategoryId;
            var category = _productService.GetCategories();
            ViewBag.Category = category;
            var products = _productService.GetProductsByNameAndByCategory(searchName,CategoryId);
            return View(products);
        }

        public IActionResult Create()
        {
            var categories = _productService.GetCategories();
            return View(categories);
        }
        public IActionResult Save(Product product)
        {
            try
            {
                if(product.Id == 0)
                {
                    _productService.CreateProduct(product);
                }
                else{
                    _productService.UpdateProduct(product);
                }
            }
            catch(Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            
            return RedirectToAction("Index");
        }

        public IActionResult Update(int Id)
        {
            var product = _productService.GetProductByID(Id);
            if(product == null)
                return RedirectToAction("Create");
            var categories = _productService.GetCategories();
            ViewBag.Product = product;
            return View(categories);
        }

        // public IActionResult UpdateProduct(Product product)
        // {
        //     _productService.UpdateProduct(product);
        //     return RedirectToAction("Index");
        // }

        public IActionResult Delete(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
            }
            catch (Exception/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            
            return RedirectToAction("Index");
        }
        // public ViewResult  Index(string name)
        // {
        //     // var product = _productService.GetProductByID(id);
        //     @ViewData["ProductName"] = name;
        //     var products = _productService.GetProductsByName(name);
        //     return View(products);
        // }

    }
}