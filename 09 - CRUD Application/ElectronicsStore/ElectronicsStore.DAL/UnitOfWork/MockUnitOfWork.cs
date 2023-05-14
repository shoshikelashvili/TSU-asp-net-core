using ElectronicsStore.DAL.Repositories.Contracts;
using ElectronicsStore.DAL.UnitOfWork.Contracts;

namespace ElectronicsStore.DAL.UnitOfWork
{
    public class MockUnitOfWork : IUnitOfWork
    {
        public IProductsRepository _productsRepository;
        public MockUnitOfWork(IProductsRepository productsRepo)
        {
            _productsRepository = productsRepo;
        }
        public IProductsRepository ProductsRepository => _productsRepository;
        public Task SaveAsync()
        {
            return Task.CompletedTask;
        }
    }
}
