using ElectronicsStore.Shared.Models;

namespace ElectronicsStore.DAL.Repositories.Contracts
{
    public interface IProductsRepository
    {
        public Task<IQueryable<Product>> ListAsync();
        public Task<Product> GetByIdAsync(int id);
    }
}