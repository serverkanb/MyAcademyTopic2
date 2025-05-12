using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace Topic.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _client;

        public LoginController(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:7211/api/"); // API base address
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            var loginData = new
            {
                Email = email,
                Password = password
            };

            var json = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                dynamic result = JsonConvert.DeserializeObject(responseBody);

                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, result.email.ToString()),
                new Claim(ClaimTypes.Role, result.role.ToString())
            };

                var identity = new ClaimsIdentity(claims, "UserScheme");
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("UserScheme", principal);

                return RedirectToAction("Index", "Default");
            }

            ViewBag.LoginError = "Giriş bilgileri hatalı.";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("UserScheme");
            return RedirectToAction("Index", "Login");
        }
    }

}
