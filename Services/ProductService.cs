using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace test_mvc.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var existedProduct = GetProductByID(id);
            if (existedProduct == null)
                return;
            _context.Products.Remove(existedProduct);
            _context.SaveChanges();

        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Product GetProductByID(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }
        public List<Product> GetProductsByName(string name)
        {
            if(string.IsNullOrEmpty(name)){
                return GetProducts();
            }
            return _context.Products.Where(p => p.Name.Contains(name)).Include(p => p.Category).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var existedProduct = GetProductByID(product.Id);
            if (existedProduct == null)
                return ;
            existedProduct.Name = product.Name;
            existedProduct.Slug = product.Slug;
            existedProduct.Price = product.Price;
            existedProduct.Quantity = product.Quantity;
            existedProduct.CategoryId = product.CategoryId;
            _context.Products.Update(existedProduct);
            _context.SaveChanges();

        }
    }
}