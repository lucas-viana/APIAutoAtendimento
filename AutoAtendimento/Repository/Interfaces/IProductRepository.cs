using AutoAtendimento.Models;
using System.Collections;

namespace AutoAtendimento.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        public Task<IEnumerable> GetProductsByCategoryAsync(int idCategory);
    }
}
