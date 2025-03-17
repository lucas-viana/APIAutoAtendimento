using AutoAtendimento.Context;
using AutoAtendimento.Models;
using AutoAtendimento.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AutoAtendimento.Repository
{

    public class ClientUserRepository : IRepository<ClientUser>
    {
        private readonly AppDbContext _context;

        public ClientUserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientUser>> GetAllAsync()
        {
            return await _context.ClientUser.ToListAsync();
        }

        public async Task<ClientUser> GetByIdAsync(int id)
        {
            return await _context.ClientUser.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ClientUser> UpdateAsync(ClientUser entity)
        {
            var selectEntity = await GetByIdAsync(entity.Id);
            if (selectEntity is null)
            {
                return null;
            }
            _context.ClientUser.Update(selectEntity);
            return entity;
        }

        public async Task<ClientUser> DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity is null)
            {
                return null;
            }

            _context.ClientUser.Remove(entity);
            return entity;
        }

        public ClientUser Create(ClientUser entity)
        {
            _context.ClientUser.Add(entity);
            return entity;
        }
    }
}
