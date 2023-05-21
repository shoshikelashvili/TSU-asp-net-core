using ElectronicsStore.Business.Services.Contracts;
using ElectronicsStore.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsStore.Web.Controllers
{
    public class AdminController : Controller
    {
		private readonly IProductsService _productsService;
		public AdminController(IProductsService productsService)
		{
			_productsService = productsService;
		}
		public async Task<IActionResult> Dashboard(int page = 1)
        {
			var (products, totalPages) = await _productsService.ListProductsAsync(5, page);
			ViewBag.Page = page;
			ViewBag.TotalPages = totalPages;

			return View(products);
        }

		public async Task<IActionResult> Edit(int productId)
		{
			var product = await _productsService.GetProductByIdAsync(productId);
            return View(product);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(Product product)
		{
			await _productsService.EditProduct(product);
			return RedirectToAction("Dashboard");
		}

		public async Task<IActionResult> Delete(int productId)
		{
			await _productsService.DeleteProduct(productId);
			return RedirectToAction("Dashboard");
		}

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            await _productsService.CreateProduct(product);
            return RedirectToAction("Dashboard");
        }
    }
}
