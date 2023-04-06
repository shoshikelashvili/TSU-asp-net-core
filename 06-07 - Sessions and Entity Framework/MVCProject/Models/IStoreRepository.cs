namespace MVCProject.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }

        IEnumerable<Product> ProductsCheaperThan400 { get; }

        IEnumerable<Product> ProductsCheaperThan400Incorrect();

        public void AddNewProduct(Product product);
    }
}
