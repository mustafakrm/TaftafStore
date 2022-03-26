using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebAPPCoreMvcUI.Models;

namespace WebAPPCoreMvcUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:44304/api/";

        

        public ProductController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsByCategoryId(Guid id)
        {
            //ErrorViewModel errorViewModel = new ErrorViewModel();
            //errorViewModel.RequestId = "salla";


            var products = await _httpClient.GetFromJsonAsync<List<Product>>(url + "Products/GetByCategoryId?categoryId=" + id);
            return View(products);
            //return View(errorViewModel);
        }
    }
}
