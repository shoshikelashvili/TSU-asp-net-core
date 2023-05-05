using ElectronicsStore.Business.Services.Contracts;
using ElectronicsStore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsStore.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;
        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }
        public async Task<IActionResult> List()
        {
            var products = await _productsService.ListProductsAsync();
            var productsViewModel = products.Select(product => new ProductViewModel(product));

            return View(productsViewModel);
        }
    }
}
