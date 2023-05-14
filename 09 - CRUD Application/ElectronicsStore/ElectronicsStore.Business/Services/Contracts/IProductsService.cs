using ElectronicsStore.Shared.Models;

namespace ElectronicsStore.Business.Services.Contracts
{
    public interface IProductsService
    {
        public Task<Product> GetProductByIdAsync(int id);
        public Task<(List<Product>, int totalPages)> ListProductsAsync(int limit, int page = 1, string orderby = "DESC");
    }
}
