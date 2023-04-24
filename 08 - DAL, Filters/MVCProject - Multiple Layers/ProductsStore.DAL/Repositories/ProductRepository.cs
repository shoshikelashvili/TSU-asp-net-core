using ProductsStore.DAL.Context;
using ProductsStore.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsStore.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private StoreDbContext _context;

        public ProductRepository(StoreDbContext ctx) => _context = ctx;

        public IQueryable<Product> Products => _context.Products;
    }
}
