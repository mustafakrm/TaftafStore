﻿using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebAPPCoreMvcUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:44304/api/";
        public AuthController( HttpClient httpClient)
        {
                _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Login()
        
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _httpClient.PostAsJsonAsync(url + "Auths/Login", userForLoginDto);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<AccessToken>();                    

                    Response.Cookies.Append("Token", data.Token,
                        new CookieOptions
                        {
                            HttpOnly = true,
                            SameSite = SameSiteMode.Strict
                        });
                    Response.Cookies.Append("exp_ti", data.Expiration.ToString(),
                        new CookieOptions
                        {
                            HttpOnly = true,
                            SameSite = SameSiteMode.Strict
                        });
                    
                    return RedirectToAction("Index", "Home");
                }
                var message= await response.Content.ReadAsStringAsync();
                ViewBag.Message=message;
               
            }           
            return View("Login");


        }

        public IActionResult LogOut()
        {
            Response.Cookies.Delete("Token");
            Response.Cookies.Delete("exp_ti");
            return RedirectToAction("Index", "Home");
        }
    }
}
