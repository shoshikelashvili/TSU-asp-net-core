namespace MVCProject.Repository
{
    public class UnitOfWork
    {
        private StoreDbContext _dbContext;
        private HistoryRepository _historyRepo;
        private ProductRepository _productRepo;

        public UnitOfWork(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public HistoryRepository HistoryRepo
        {
            get
            {
                if (_historyRepo is null)
                    _historyRepo = new HistoryRepository(_dbContext);
                return _historyRepo;
            }
        }

        public ProductRepository ProductRepo
        {
            get
            {
                if(_productRepo is null)
                    _productRepo = new ProductRepository(_dbContext);
                return _productRepo;
            }
        }

        public void Save() => _dbContext.SaveChanges();
    }
}
