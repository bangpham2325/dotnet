using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_mvc.Models;

namespace test_mvc.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Product? GetProductByID(int id);

        void CreateProduct(Product product);

        void UpdateProduct(Product product);
        void DeleteProduct(int id);
        List<Category> GetCategories();
        List<Product> GetProductsByNameAndByCategory(string name, int category_id);
    }
}