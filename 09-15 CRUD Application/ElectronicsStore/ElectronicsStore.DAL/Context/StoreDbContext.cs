using ElectronicsStore.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectronicsStore.DAL.Context
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }
        public DbSet<Product> Products => Set<Product>();
    }
}
