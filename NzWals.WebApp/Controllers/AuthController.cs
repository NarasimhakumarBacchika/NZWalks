using Microsoft.AspNetCore.Mvc;
using NZWalks.API.DTO;
using NzWals.WebApp.Models;

namespace NzWals.WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthController(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public IActionResult Login1()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login1(LoginRequestVM login)
        {
            if (!ModelState.IsValid)
                return View(login);

            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("http://localhost:5085/api/Auth/Login", login);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<LoginResponseDto>();

                // Store in session
                HttpContext.Session.SetString("JWToken", result.JwtToken);
                //HttpContext.Session.SetString("Username", result.Username);
               // HttpContext.Session.SetString("Roles", string.Join(",", result.Roles));

                return RedirectToAction("Index", "Home");
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                ViewData["Message"] = "Login failed. " + error;
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }


    }
} 
