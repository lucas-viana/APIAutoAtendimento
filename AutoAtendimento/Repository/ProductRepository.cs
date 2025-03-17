using AutoAtendimento.Context;
using AutoAtendimento.Models;
using AutoAtendimento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;

namespace AutoAtendimento.Repository
{
    public class ProductRepository(AppDbContext context) : Repository<Product>(context), IProductRepository
    {
        public Product Create(Product product)
        {
            _context.Add(product);
            return product;
        }

        public async Task<Product> DeleteAsync(Product product)
        {
            var selectProduct = await GetByIdAsync(product.Id);
            _context.Set<Product>().Remove(product);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Set<Product>().AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetAsync(Product product)
        {
            return await _context.Set<Product>().AsNoTracking().FirstOrDefaultAsync(p => p.Id == product.Id);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var selectProduct = await GetByIdAsync(product.Id);

            if (selectProduct is null)
            {
                return null;
            }

            _context.Update(selectProduct);
            return product;
        }

        public async Task<IEnumerable> GetProductsByCategoryAsync(int idCategory)
        {
            var products = await _context.Product.Where(p => p.CategoryId == idCategory).ToListAsync();
            return products;
        }
    }
}
