using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_mvc.Models;


namespace test_mvc.Services
{
    public class CategoryService : ICategoryService
    {
         private readonly DataContext _context;
        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public void CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var existedCategory = GetCategoryByID(id);
            if (existedCategory == null)
                return;
            _context.Categories.Remove(existedCategory);
            _context.SaveChanges();

        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryByID(int id)
        {
            return _context.Categories.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateCategory(Category category)
        {
            var existedProduct = GetCategoryByID(category.Id);
            if (existedProduct == null)
                return ;
            existedProduct.Name = category.Name;
            _context.Categories.Update(existedProduct);
            _context.SaveChanges();

        }
        
    }
}