namespace MVCProject.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private StoreDbContext _dbContext;

        public GenericRepository(StoreDbContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return _dbContext.Set<T>().Find(id);
        }
    }
}
