using ElectronicsStore.DAL.Context;
using ElectronicsStore.DAL.Repositories.Contracts;
using ElectronicsStore.DAL.UnitOfWork.Contracts;

namespace ElectronicsStore.DAL.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private StoreDbContext _dbContext;
        public IProductsRepository _productsRepository;
        public EFUnitOfWork(IProductsRepository productsRepo, StoreDbContext dbContext)
        {
            _productsRepository = productsRepo;
            _dbContext = dbContext;
        }
        public IProductsRepository ProductsRepository => _productsRepository;
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
