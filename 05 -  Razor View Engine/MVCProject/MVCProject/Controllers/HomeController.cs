﻿using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public IEnumerable<Product> ProductsMockData {get;set;} = new List<Product>()
        {
            new Product
            {
                DateAdded = DateTime.Now,
                Name = "Guitar",
                Description = $"Test description",
                Id = 1,
                Price = 100
            },
            new Product
            {
                DateAdded = DateTime.Now,
                Name = "Piano",
                Description = $"Test description",
                Id = 2,
                Price = 200
            },
        };

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult ListProducts()
        {
            var productsMock = new List<Product>()
            {
                new Product
                {
                    DateAdded = DateTime.Now,
                    Name = "Guitar",
                    Description = $"Test description",
                    Id = 1,
                    Price = 100
                },
                new Product
                {
                    DateAdded = DateTime.Now,
                    Name = "Piano",
                    Description = $"Test description",
                    Id = 2,
                    Price = 200
                },
            };

            ViewData["ProductsList"] = productsMock;
            //ViewData["ProductsList"] = "Test Statement";

            ViewBag.Products = productsMock;

            return View(productsMock);

            //Other ways we can use to access views
            //return View("Views/Home/ListProducts.cshtml", productsMock);
            //return View("../Home/ListProducts", productsMock);
            //return View("./ListProducts", productsMock);
        }

        public IActionResult GetById(int id, bool deleted)
        {
            return Ok($"id = {id}, deleted = {deleted}");
        }

        //public IActionResult AddProduct(int id, string Name, DateTime DateAdded, string Description, decimal Price)
        //{
        //    var productData = new Product()
        //    {
        //        Id = id,
        //        Name = Name,
        //        DateAdded = DateAdded,
        //        Description = Description,
        //        Price = Price
        //    };

        //    return Ok($"id = {productData.Id}, name = {productData.Name}, date = {productData.DateAdded}, desc =  {productData.Description}, price = {productData.Price}");
        //}

        [HttpPost]
        public IActionResult AddProduct(Product productData)
        {
            return Json($"id = {productData.Id}, name = {productData.Name}, date = {productData.DateAdded}, desc =  {productData.Description}, price = {productData.Price}");
        }



        [NonAction]
        public IActionResult CalculateAdditionalData()
        {
            //logic...
            return Ok();
        }

        private IActionResult CalculateExtraData()
        {
            //logic...
            return Ok();
        }
    }
}