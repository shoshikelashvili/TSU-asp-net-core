using ElectronicsStore.DAL.Context;
using ElectronicsStore.DAL.Repositories.Contracts;
using ElectronicsStore.Shared.Models;

namespace ElectronicsStore.DAL.Repositories
{
    public class EFProductsRepository : IProductsRepository
    {
        private readonly StoreDbContext _context;
        public EFProductsRepository(StoreDbContext context) => _context = context;

        public async Task<(IQueryable<Product> productsQueryable, int totalPages)> ListAsync(int limit, int page, string orderBy)
        {
            var products = orderBy == "DESC" ? _context.Products.OrderByDescending(product => product.Id) : _context.Products.OrderBy(product => product.Id);
            var totalPages = Math.Ceiling((decimal)products.Count() / limit);

            return (await Task.FromResult(products.Skip(limit * (page - 1)).Take(limit)), (int)totalPages);
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await Task.FromResult(_context.Products.First(product => product.Id == id));
        }

        public Task CreateProduct(Product product)
        {
            product.AddDate = DateTime.Now;
            _context.Products.Add(product);
            return Task.CompletedTask;
        }

        public Task DeleteProduct(int id)
        {
            var product = new Product { Id = id };
            _context.Products.Attach(product);
            _context.Products.Remove(product);
            return Task.CompletedTask;
        }

        public Task EditProduct(Product product)
        {
            var productToUpdate = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            productToUpdate.ServicePrice = product.ServicePrice;
            productToUpdate.BasePrice = product.BasePrice;
            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Brand = product.Brand;
            productToUpdate.ImageURL = product.ImageURL;
            productToUpdate.IsAvailable = product.IsAvailable;
            productToUpdate.ChangeDate = DateTime.Now;
            return Task.CompletedTask;
        }
    }
}
