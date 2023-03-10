using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebAPPCoreMvcUI.CustomFilterAttribute;
using WebAPPCoreMvcUI.Models.ProductViewModel;

namespace WebAPPCoreMvcUI.Controllers
{
    [MyCustomAttribute]
    public class ProductController : Controller
    {
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:44304/api/";
        private readonly IWebHostEnvironment _hostEnvironment;
        public ProductController(HttpClient httpClient, IWebHostEnvironment hostEnvironment)
        {
            _httpClient = httpClient;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> AddProduct()
        {
            //Create New Product 
            var model = new ProductAddViewModel();
            var subCategList = await _httpClient.
               GetFromJsonAsync<List<SubCategory>>(url + "SubCategories/getAll");

            ViewBag.SubCategoriesList = new SelectList(subCategList, "Id", "SubCategoryName");

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddViewModel productAddViewModel)
        {

            if (ModelState.IsValid)
            {
                if (productAddViewModel.Files != null)
                {
                    Product productToAdd = new Product()
                    {

                        ProductName = productAddViewModel.ProductName,
                        Description = productAddViewModel.Description,
                        PurchasePrice = productAddViewModel.PurchasePrice,
                        SalePrice = productAddViewModel.SalePrice,
                        DiscountPrice = productAddViewModel.DiscountPrice,
                        AddedDate = productAddViewModel.AddedDate,
                        UnitsInstock = productAddViewModel.UnitsInstock,
                        SubCategoryId = productAddViewModel.SubCategoryId,
                        IsDeleted = productAddViewModel.IsDeleted

                    };

                    AddRequestHeaderToken();
                    HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Products/add", productToAdd);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        return RedirectToAction("GetAllProducts", "Product");
                    }

                }
            }
            return View();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            AddRequestHeaderToken();
            var products = await _httpClient.GetFromJsonAsync<List<Product>>(url + "Products/getAll");
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> ProductsByCategoryId(Guid id)
        {
            AddRequestHeaderToken();
            var products = await _httpClient.GetFromJsonAsync<List<Product>>(url + "Products/GetByCategoryId?categoryId=" + id);

            foreach (var item in products)
            {
                var images = await _httpClient.GetFromJsonAsync<List<Image>>(url + "Images/getByproductId?productId=" + item.Id);
                item.Images = images;
            }


            return View(products);
        }
       

        [HttpGet]
        public async Task<IActionResult> ProductDetail(Guid id)
        {
            var product = await _httpClient.GetFromJsonAsync<Product>(url + "Products/GetById?productId=" + id);
            var subCategory = await _httpClient.GetFromJsonAsync<SubCategory>(url + "SubCategories/getById?subCategoryId=" + product.SubCategoryId);
            var images = await _httpClient.GetFromJsonAsync<List<Image>>(url + "Images/getByproductId?productId=" + id);
            product.Images = images;
            ViewBag.SubcategoryName = subCategory.SubCategoryName;

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(Guid id)
        {
            var productToUpdate = await _httpClient.GetFromJsonAsync<Product>(url + "Products/getById?productId=" + id);
            
            var subCategList = await _httpClient.
              GetFromJsonAsync<List<SubCategory>>(url + "SubCategories/getAll");

            ViewBag.SubCategoriesList = new SelectList(subCategList, "Id", "SubCategoryName");
            return View(productToUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync<Product>(url + "Products/Update", product);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllProducts", "Product");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var productToDelete = await _httpClient.GetFromJsonAsync<Product>(url + "Products/getById?productId=" + id);
            
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

        public void AddRequestHeaderToken()
        {
            var token = Request.Cookies["Token"];
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
        }

        private async Task<string> UploadImage(string folderPath, IFormFile formFile)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + formFile.FileName;
            string serverFolder = Path.Combine(_hostEnvironment.WebRootPath, folderPath);
            await formFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
        }
    }
}
