using Microsoft.AspNetCore.Mvc;
using ProductsStore.Business.Services;
using ProductsStore.DAL.Repositories;

namespace ProductsStore.Web.Controllers
{
    public class ProductsController : Controller
    {
        private ProductService _productService;
        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult ListProducts()
        {
            var products = _productService.ProductsList();
            return View(products);
        }
    }
}
