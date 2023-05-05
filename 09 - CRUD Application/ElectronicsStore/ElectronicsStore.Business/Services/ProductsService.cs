using ElectronicsStore.Business.Services.Contracts;
using ElectronicsStore.DAL.Repositories.Contracts;
using ElectronicsStore.Shared.Models;

namespace ElectronicsStore.Business.Services
{
    public class ProductsService : IProductsService
    {
        private IProductsRepository _productRepo;
        public ProductsService(IProductsRepository productRepo)
        {
            _productRepo = productRepo;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            var result = await _productRepo.GetByIdAsync(id);
            return result;
        }

        public async Task<List<Product>> ListProductsAsync()
        {
            var result = await _productRepo.ListAsync();
            return result.ToList();
        }
    }
}
