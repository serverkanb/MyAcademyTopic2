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
            try
            {
                var jsonData = JsonConvert.SerializeObject(dto);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("subscriber", content); // "subscribers" değil "subscriber" çünkü API öyle

                if (response.IsSuccessStatusCode)
                {
                    TempData["SubscribeMessage"] = "Teşekkürler, abone oldunuz!";
                    return RedirectToAction("Index", "Default");
                }

                TempData["SubscribeMessage"] = "Abonelik işlemi sırasında bir hata oluştu.";
                return RedirectToAction("Index", "Default");
            }
            catch (Exception ex)
            {
                TempData["SubscribeMessage"] = "Sistemsel bir hata oluştu: " + ex.Message;
                return RedirectToAction("Index", "Default");
            }
        }

    }
}
