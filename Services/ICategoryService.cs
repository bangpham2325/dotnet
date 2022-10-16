using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_mvc.Models;

namespace test_mvc.Services
{
    public interface ICategoryService
    {
        List<Category> GetCategories();

        Category? GetCategoryByID(int id);

        void CreateCategory(Category category);

        void UpdateCategory(Category category);
        void DeleteCategory(int id);
    }
}