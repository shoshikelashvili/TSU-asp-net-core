using ProductsStore.DAL.Models;
using ProductsStore.DAL.Repositories;

namespace ProductsStore.Business.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public List<Product> ProductsList()
        {
            //Can add custom logic here
            return _repository.Products.Take(2).ToList();
        }
    }
}