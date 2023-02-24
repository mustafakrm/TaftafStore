using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebAPPCoreMvcUI.Models.ProductViewModel;

namespace WebAPPCoreMvcUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:44304/api/";
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(HttpClient httpClient,IWebHostEnvironment hostEnvironment)
        {
            _httpClient=httpClient;
            _hostEnvironment=hostEnvironment;
        }
       
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new ProductAddViewModel();

            var subCategList = await _httpClient.
               GetFromJsonAsync<List<SubCategory>>(url + "SubCategories/getAll");

            ViewBag.SubCategoriesList = new SelectList(subCategList, "Id", "SubCategoryName");

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductAddViewModel productAddViewModel)
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products=await _httpClient.GetFromJsonAsync<List<Product>>(url+"Products/getAll");
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> ProductsByCategoryId(Guid id)
        {
            var products = await _httpClient.GetFromJsonAsync<List<Product>>(url + "Products/GetByCategoryId?categoryId=" + id);

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            var subCategList = await _httpClient.
               GetFromJsonAsync<List<SubCategory>>(url + "SubCategories/getAll");

            ViewBag.SubCategoriesList = new SelectList(subCategList, "Id", "SubCategoryName");
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
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            var product = await _httpClient.GetFromJsonAsync<Product>(url + "Products/getById?productId=" + id);
            Product productToUpdate = new Product()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description=product.Description,
                PurchasePrice = product.PurchasePrice,
                SalePrice = product.SalePrice,
                DiscountPrice = product.DiscountPrice,
                AddedDate = product.AddedDate,
                UnitsInstock = product.UnitsInstock,
                SubCategoryId = product.SubCategoryId,
                IsDeleted = product.IsDeleted
            };
            var subCategList = await _httpClient.
              GetFromJsonAsync<List<SubCategory>>(url + "SubCategories/getAll");

            ViewBag.SubCategoriesList = new SelectList(subCategList, "Id", "SubCategoryName");
            return View(productToUpdate);
        }
        
        [HttpPost]
        public async Task<IActionResult>UpdateProduct(Product product)
        {
            HttpResponseMessage responseMessage= await _httpClient.PostAsJsonAsync<Product>(url +"Products/Update",product);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllProducts", "Product");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product=await _httpClient.GetFromJsonAsync<Product>(url +"Products/getById?productId="+id);

            Product productToDelete = new Product()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Description = product.Description,
                PurchasePrice = product.PurchasePrice,
                SalePrice = product.SalePrice,
                DiscountPrice = product.DiscountPrice,
                AddedDate = product.AddedDate,
                UnitsInstock = product.UnitsInstock,
                SubCategoryId = product.SubCategoryId,
                IsDeleted = product.IsDeleted
            };
            return View(productToDelete);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Product product)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync<Product>(url + "Products/Delete", product);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllProducts", "Product");
            }
            return View();
        }
    }
}
