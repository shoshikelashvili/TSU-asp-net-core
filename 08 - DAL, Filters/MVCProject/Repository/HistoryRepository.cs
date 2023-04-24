using MVCProject.Models;

namespace MVCProject.Repository
{
    public class HistoryRepository : IHistoryRepository
    {
        private StoreDbContext _dbContext;
        public HistoryRepository(StoreDbContext context)
        {
            _dbContext = context;
        }
        public void AddNewRecord(History record)
        {
            _dbContext.ProductHistories.Add(record);
            //_dbContext.SaveChanges();
        }
    }
}
