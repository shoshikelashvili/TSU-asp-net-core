using Microsoft.EntityFrameworkCore;
using MVCProject.Models;

namespace MVCProject.Repository
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<History> ProductHistories => Set<History>();
    }
}
