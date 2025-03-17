using System.Collections;
using System.Linq.Expressions;

namespace AutoAtendimento.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<T> UpdateAsync(T entity);
        public Task<T> DeleteAsync(int id);
        public T Create(T entity);
    }
}
