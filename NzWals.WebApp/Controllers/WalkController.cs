using Microsoft.AspNetCore.Mvc;
using NZWalks.API.DTO;
using NzWals.WebApp.Models;
using System.Net.Http.Headers;

namespace NzWals.WebApp.Controllers
{
    public class WalkController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WalkController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> List()
        {
            //var token = HttpContext.Session.GetString("JWToken");

            //if (string.IsNullOrEmpty(token))
            //{
            //    return RedirectToAction("Login", "Auth");
            //}

            var client = _httpClientFactory.CreateClient();
           // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync("http://localhost:5085/api/Walk/GetAll");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadFromJsonAsync<List<WalksVM>>();
                return View(data);
            }
            return View("Error");
        }
     }
}
