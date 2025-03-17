using AutoAtendimento.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoAtendimento.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ClientUser> ClientUser { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<StockItem> StockItem { get; set; }
        public DbSet<Stock> Stock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
