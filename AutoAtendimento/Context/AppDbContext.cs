using AutoAtendimento.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoAtendimento.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Table> Tables { get; set; }

    }
}
