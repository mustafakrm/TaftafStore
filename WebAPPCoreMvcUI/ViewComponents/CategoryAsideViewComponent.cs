using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebAPPCoreMvcUI.ViewComponents
{
    public class CategoryAsideViewComponent: ViewComponent
    {
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:44304/api/";

        public CategoryAsideViewComponent(HttpClient httpClient)
        {
            _httpClient=httpClient;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _httpClient.
                 GetFromJsonAsync<List<Category>>(url + "Categories/getAll");
            return View(categories);
        }
    }
}
