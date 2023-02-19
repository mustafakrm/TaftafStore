using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebAPPCoreMvcUI.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly HttpClient _httpClient;
        private string url= "https://localhost:44304/api/";
        public SubCategoryController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubCategories()
        {
            var subCategories = await _httpClient.
                GetFromJsonAsync<List<SubCategory>>(url + "SubCategories/getAll");

            return View(subCategories);
        }

        [HttpGet]
        public IActionResult AddSubCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddSubCategory(SubCategory subCategory)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "SubCategories/Add", subCategory);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllSubCategories", "SubCategory");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSubCategory(Guid id)
        {
            var subCategory = await _httpClient.GetFromJsonAsync<SubCategory>(url + "SubCategories/getById?subCategoryId=" + id);

            SubCategory subCateg = new SubCategory()
            {
                Id = subCategory.Id,
                SubCategoryName = subCategory.SubCategoryName,
                CategoryId=subCategory.CategoryId,
                IsDeleted = subCategory.IsDeleted
            };

            return View(subCateg);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSubCategory(SubCategory subCategory)
        {

            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "SubCategories/Update", subCategory);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllSubCategories", "SubCategory");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DeleteSubCategory(Guid id)
        {
            var subCategory = await _httpClient.GetFromJsonAsync<SubCategory>(url + "SubCategories/getById?subCategoryId=" + id);
            SubCategory subCateg = new SubCategory()
            {
                Id = subCategory.Id,
                SubCategoryName = subCategory.SubCategoryName,
                CategoryId = subCategory.CategoryId,
                IsDeleted = subCategory.IsDeleted
            };

            return View(subCateg);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSubCategory(SubCategory subCategory)
        {
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "SubCategories/Delete", subCategory);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GetAllSubCategories", "SubCategory");
            }
            return View();
        }
    }
}
