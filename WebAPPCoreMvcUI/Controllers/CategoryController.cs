using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebAPPCoreMvcUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:44304/api/";

        public CategoryController(HttpClient httpClient)
        {
            _httpClient=httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _httpClient.GetFromJsonAsync<List<Category>>(url + "Categories/getAll");
            if (categories!=null)
            {
               
            }
           
            return View(categories);
        }
    }
}
