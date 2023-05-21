using ElectronicsStore.Business.Services.Contracts;
using ElectronicsStore.DAL.UnitOfWork.Contracts;
using ElectronicsStore.Shared.Models;

namespace ElectronicsStore.Business.Services
{
    public class ProductsService : IProductsService
    {
        private IUnitOfWork _unitOfWork;
        public ProductsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var result = await _unitOfWork.ProductsRepository.GetByIdAsync(id);
            return result;
        }

        public async Task<(List<Product>, int totalPages)> ListProductsAsync(int limit, int page = 1, string orderby = "DESC")
        {
            var result = await _unitOfWork.ProductsRepository.ListAsync(limit, page, orderby);
            return (result.productsQueryable.ToList(), result.totalPages);
        }

        public async Task CreateProduct(Product product)
        {
            await _unitOfWork.ProductsRepository.CreateProduct(product);
        }

        public async Task DeleteProduct(int id)
        {
            await _unitOfWork.ProductsRepository.DeleteProduct(id);
        }

        public async Task EditProduct(Product product)
        {
            await _unitOfWork.ProductsRepository.EditProduct(product);
        }
    }
}