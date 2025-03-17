using AutoAtendimento.Context;
using AutoAtendimento.Models.Interfaces;
using AutoAtendimento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AutoAtendimento.Repository
{
    public class Repository<T>(AppDbContext context) : IRepository<T> where T : class, IEntity
    {
        protected readonly AppDbContext _context = context;

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id) 
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public T Create(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Set<T>().Add(entity);
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity is null)
            {
                return null;
            }
            _context.Set<T>().Remove(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            if(entity is null)
            {
                return null;
            }

            _context.Set<T>().Update(entity);
            return entity;
        }

    }
}
