using ElectronicsStore.Shared.Models;

namespace ElectronicsStore.DAL.Repositories.Contracts
{
    public interface IProductsRepository
    {
        public Task<(IQueryable<Product> productsQueryable,int totalPages)> ListAsync(int limit, int page, string orderBy);
        public Task<Product> GetByIdAsync(int id);
        public Task CreateProduct(Product product);
        public Task DeleteProduct(int id);
        public Task EditProduct(Product product);
    }
}