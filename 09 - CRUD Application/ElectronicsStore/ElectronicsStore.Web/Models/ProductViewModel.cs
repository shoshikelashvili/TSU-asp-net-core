using ElectronicsStore.Shared.Models;

namespace ElectronicsStore.Web.Models
{
    public class ProductViewModel
    {
        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Price = product.ServicePrice + product.BasePrice;
            ImageURL = product.ImageURL;
            IsAvailable = product.IsAvailable;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public bool IsAvailable { get; set; }
    }
}