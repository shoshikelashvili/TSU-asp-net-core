﻿using ElectronicsStore.Business.Services.Contracts;
using ElectronicsStore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ElectronicsStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsService _productsService;
        public HomeController(IProductsService productService)
        {
            _productsService = productService;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["isHome"] = true;

            var (products, _) = await _productsService.ListProductsAsync(6);
            var productsViewModel = products.Select(product => new ProductViewModel(product));

            return View(productsViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}