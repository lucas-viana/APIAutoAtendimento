using AutoAtendimento.Models;

namespace AutoAtendimento.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IRepository<Category> CategoryRepository { get; }
        IRepository<ClientUser> ClientUserRepository { get; }

        Task CommitAsync();
    }
}
