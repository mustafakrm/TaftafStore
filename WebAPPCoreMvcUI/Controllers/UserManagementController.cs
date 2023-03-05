using Core.Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebAPPCoreMvcUI.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:44304/api/";
        private readonly IWebHostEnvironment _hostEnvironment;

        public UserManagementController(HttpClient httpClient,IWebHostEnvironment hostEnvironment)
        {
            _httpClient = httpClient;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddOperationClaim()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddOperationClaim(OperationClaim operationClaim)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "OperationClaims/Add", operationClaim);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Home");
                }               
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddUserOperationClaim()
        {
            //Todo: Get user and operation claim id and name, add to viewmodel send to view 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddUserOperationClaim(UserOperationClaim userOperationClaim)
        {
            //Todo:Get user and operation claim id's from viewmodel then send to api
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "UserOperationClaims/Add", userOperationClaim);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        
    }
}
