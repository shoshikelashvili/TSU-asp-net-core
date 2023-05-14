using ElectronicsStore.DAL.Repositories.Contracts;

namespace ElectronicsStore.DAL.UnitOfWork.Contracts
{
    public interface IUnitOfWork
    {
        public IProductsRepository ProductsRepository { get; }
        public Task SaveAsync();
    }
}
