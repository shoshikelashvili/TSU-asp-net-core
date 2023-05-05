namespace ElectronicsStore.Shared.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal BasePrice { get; set; }
    public decimal ServicePrice { get; set; }
    public bool IsAvailable { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public string ImageURL { get; set; }
    public DateTime AddDate { get; set; }
    public DateTime ChangeDate { get; set; }
}