using MVCProject.Models;

namespace MVCProject.Repository
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        IEnumerable<Product> ProductsCheaperThan400 { get; }

        IEnumerable<Product> ProductsCheaperThan400Incorrect();

        public void AddNewProduct(Product product);
    }
}
