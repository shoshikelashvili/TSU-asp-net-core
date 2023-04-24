using MVCProject.Models;

namespace MVCProject.Repository
{
    public class ProductRepository : IProductRepository
    {
        private StoreDbContext _context;

        public ProductRepository(StoreDbContext ctx) => _context = ctx;

        public IQueryable<Product> Products => _context.Products;

        public IEnumerable<Product> ProductsCheaperThan400 => _context.Products.Where(x => x.Price < 400);

        public IEnumerable<Product> ProductsCheaperThan400Incorrect()
        {
            var products = _context.Products.ToList();
            return products.Where(x => x.Price < 400);
        }

        public void AddNewProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
