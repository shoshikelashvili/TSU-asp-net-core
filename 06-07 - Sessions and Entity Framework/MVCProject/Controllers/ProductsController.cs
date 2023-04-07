using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class ProductsController : Controller
    {
        private IStoreRepository _storeRepository;
        public int PageSize = 2;
        public ProductsController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }
        public IActionResult ListProducts()
        {
            //var products = new List<Product>()
            //{
            //    new Product
            //    {
            //        DateAdded = DateTime.Now,
            //        Name = "Guitar",
            //        Description = $"Test description",
            //        Id = 1,
            //        Price = 100
            //    },
            //    new Product
            //    {
            //        DateAdded = DateTime.Now,
            //        Name = "Piano",
            //        Description = $"Test description",
            //        Id = 2,
            //        Price = 200
            //    },
            //};
            var products = _storeRepository.Products;

            return View(products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product productData)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _storeRepository.AddNewProduct(productData);
            return Ok("Product added successfully");
        }

        public IActionResult ListProductsPaged(int productPage = 1)
        {
            return View("ListProducts", _storeRepository.Products.OrderBy(p => p.Id).Skip((productPage - 1) * PageSize).Take(PageSize));
        }

        public IActionResult ListProductsWithViewModel()
        {
            var products = _storeRepository.ProductsCheaperThan400;
            var productsViewModel = products.Select(x => new ProductViewModel { Name = x.Name, Description = x.Description, Price = x.Price});
            return View("ListProductsWithViewModel", productsViewModel);
        }

        public IActionResult CheapProducts()
        {
            return View("ListProducts", _storeRepository.ProductsCheaperThan400);
        }

        public IActionResult CheapProductsIncorrect()
        {
            return View("ListProducts", _storeRepository.ProductsCheaperThan400Incorrect());
        }

        public IActionResult GetCookies()
        {
            var cookiesText = "";
            foreach (var cookie in HttpContext.Request.Cookies)
                cookiesText += $"Key: {cookie.Key}, Value: {cookie.Value}\n"; 

            return Ok(cookiesText);
        }

        public IActionResult AddCookiesToResponse()
        {
            HttpContext.Response.Cookies.Append("cookie1", "value1");
            HttpContext.Response.Cookies.Append("cookie2", "value2");
            HttpContext.Response.Cookies.Append("cookie3", "value3", new CookieOptions { IsEssential = true});
            return Ok();
        }

        public IActionResult RemoveCookiesFromResponse()
        {
            HttpContext.Response.Cookies.Delete("cookie1");
            return Ok();
        }
    }
}
