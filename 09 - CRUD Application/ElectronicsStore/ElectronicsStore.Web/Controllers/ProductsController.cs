using Microsoft.AspNetCore.Mvc;

namespace ElectronicsStore.Web.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
