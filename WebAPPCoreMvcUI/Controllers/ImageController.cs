using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebAPPCoreMvcUI.Models.ProductViewModel;

namespace WebAPPCoreMvcUI.Controllers
{
    public class ImageController : Controller
    {
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:44304/api/";
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImageController(HttpClient httpClient, IWebHostEnvironment hostEnvironment)
        {
            _httpClient = httpClient;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> AddProductImages(Guid id)
        {
            
            var product = await _httpClient.GetFromJsonAsync<Product>(url + "Products/getById?productId=" + id);

            ViewBag.ProductName = product.ProductName;
            ViewBag.ProductId = product.Id;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProductImages(ProductAddViewModel productAddViewModel)
        {

            if (ModelState.IsValid)
            {
                if (productAddViewModel.Files != null)
                {                   
                    string folder = "Images/ProductImages/";
                    Image image = new Image();
                    foreach (var item in productAddViewModel.Files)
                    {
                        image.ImageName = item.FileName;
                        image.ProductId=productAddViewModel.ProductId;
                        var Path = await UploadImage(folder, item);
                        image.ImagePath = Path.ToString();
                        await _httpClient.PostAsJsonAsync(url + "Images/Add", image);

                    }
                    
                    return RedirectToAction("GetAllProducts", "Product");
                }

            }
            return View();
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
