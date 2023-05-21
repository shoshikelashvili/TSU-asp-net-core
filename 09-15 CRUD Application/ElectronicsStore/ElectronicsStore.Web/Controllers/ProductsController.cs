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
        public async Task<IActionResult> List(int page = 1)
        {
            var (products, totalPages) = await _productsService.ListProductsAsync(9, page);
            var productsViewModel = products.Select(product => new ProductViewModel(product));
            ViewBag.Page = page;
            ViewBag.TotalPages = totalPages;

            return View(productsViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productsService.GetProductByIdAsync(id);
            var productViewModel = new ProductViewModel(product);

            return View(productViewModel);
        }
    }
}
