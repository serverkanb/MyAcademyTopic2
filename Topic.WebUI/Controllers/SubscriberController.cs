using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using Topic.WebUI.Dtos.SubscriberDtos;
using Topic.WebUI.Models;
using System.Diagnostics;


namespace Topic.WebUI.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly HttpClient _client;

        public SubscriberController(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:7211/api/");
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscriber(CreateSubscriberDto dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["SubscribeMessage"] = "Lütfen geçerli bilgiler girin.";
                return RedirectToAction("Index", "Default");
            }

            try
            {
                var jsonData = JsonConvert.SerializeObject(dto); // artık sade model
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("subscriber", content);

                TempData["SubscribeMessage"] = response.IsSuccessStatusCode
                    ? "Teşekkürler, başarıyla abone oldunuz!"
                    : "Abonelik sırasında bir sorun oluştu.";
            }
            catch (Exception ex)
            {
                TempData["SubscribeMessage"] = "Sistem hatası: " + ex.Message;
            }

            return RedirectToAction("Index", "Default");
        }

    }
}
