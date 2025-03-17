using AutoAtendimento.Context;
using AutoAtendimento.Models;
using AutoAtendimento.Repository.Interfaces;

namespace AutoAtendimento.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IProductRepository _productRepository;
        private IRepository<Category> _categoryRepository;
        public AppDbContext _unitOfWork;

        public UnitOfWork(AppDbContext context)
        {
            _unitOfWork = context;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository = _productRepository ?? new ProductRepository(_unitOfWork);
            }
        }

        public IRepository<Category> CategoryRepository
        {
            get
            {
                return _categoryRepository = _categoryRepository ?? new Repository<Category>(_unitOfWork);
            }
        }


        public async Task CommitAsync()
        {
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Dispose()
        {
            await _unitOfWork.DisposeAsync();
        }
    }
}
