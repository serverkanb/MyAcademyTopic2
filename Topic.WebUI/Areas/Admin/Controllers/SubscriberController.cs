using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Topic.WebUI.Dtos.SubscriberDtos;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    [Authorize(Roles = "ADMIN")]
    public class SubscriberController : Controller
    {
        private readonly HttpClient _client;

        public SubscriberController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("https://localhost:7211/api/subscriber");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSubscriberDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateSubscriber()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscriber(CreateSubscriberDto dto)
        {
            var jsonData = JsonConvert.SerializeObject(dto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("https://localhost:7211/api/subscriber", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }

        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            var response = await _client.DeleteAsync($"https://localhost:7211/api/subscriber/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSubscriber(int id)
        {
            var response = await _client.GetAsync($"https://localhost:7211/api/subscriber/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<UpdateSubscriberDto>(json);
                return View(data);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubscriber(UpdateSubscriberDto dto)
        {
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("https://localhost:7211/api/subscriber", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }
    }
}
