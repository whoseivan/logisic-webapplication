using LogisticApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticApp.Data
{
    public class AppDbContext : DbContext
    {
        // Здесь мы определяем таблицы (DbSet) для всех моделей
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Logistician> Logisticians { get; set; }
        public DbSet<Routes> Routes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
