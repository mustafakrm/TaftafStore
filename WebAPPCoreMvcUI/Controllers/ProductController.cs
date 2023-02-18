﻿using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebAPPCoreMvcUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:44304/api/";
        public ProductController(HttpClient httpClient)
        {
            _httpClient=httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products=await _httpClient.GetFromJsonAsync<List<Product>>(url+"Products/getAll");
            return View(products);
        }

        [HttpGet]
        public  IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Products/add", product);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllProducts", "Product");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProductsByCategoryId(Guid id)
        {
            var products = await _httpClient.GetFromJsonAsync<List<Product>>(url + "Products/GetByCategoryId?categoryId=" + id);
            
            return View(products);
        }
    }
}
