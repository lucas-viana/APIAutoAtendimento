using System.Collections;
using System.Linq.Expressions;

namespace AutoAtendimento.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetAsync(Expression<Func<T,bool>> predicate);
        public T Update(T entity);
        public T Delete(T entity);
        public T Create(T entity);
    }
}
