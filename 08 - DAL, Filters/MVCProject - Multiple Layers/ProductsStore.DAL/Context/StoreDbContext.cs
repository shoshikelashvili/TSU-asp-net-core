using Microsoft.EntityFrameworkCore;
using ProductsStore.Shared.Models;
using System.Collections.Generic;

namespace ProductsStore.DAL.Context
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) { }
        public DbSet<Product> Products => Set<Product>();
        public DbSet<History> ProductHistories => Set<History>();
    }
}