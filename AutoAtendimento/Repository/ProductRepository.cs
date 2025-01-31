using AutoAtendimento.Context;
using AutoAtendimento.Models;
using AutoAtendimento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq.Expressions;

namespace AutoAtendimento.Repository
{
    public class ProductRepository(AppDbContext context) : Repository<Product>(context) , IProductRepository 
    {
        public Product Create(Product entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            _context.Add(entity);
            return entity;
        }

        public Product Delete(Product entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Set<Product>().Remove(entity);
            return entity;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Set<Product>().AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetAsync(Expression<Func<Product, bool>> predicate)
        {
            return await _context.Set<Product>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }

        public Product Update(Product entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Update(entity);
            return entity;
        }

        public async Task<IEnumerable> GetProductsByCategory(int idCategory)
        {
            var products = await _context.Products.Where(p => p.CategoryId == idCategory).ToListAsync();
            return products;
        }
    }
}
