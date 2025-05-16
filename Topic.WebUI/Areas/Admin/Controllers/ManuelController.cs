using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Topic.WebUI.Dtos.ManuelDtos;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    [Authorize(Roles = "ADMIN")]
    public class ManuelController : Controller
    {
        private readonly HttpClient _client;

        public ManuelController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _client.GetAsync("https://localhost:7211/api/manuels");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultManuelDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateManuel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateManuel(CreateManuelDto createManuelDto)
        {
            var content = JsonConvert.SerializeObject(createManuelDto);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PostAsync("https://localhost:7211/api/manuels", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DeleteManuel(int id)
        {
            var responseMessage = await _client.DeleteAsync("https://localhost:7211/api/manuels/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateManuel(int id)
        {
            var responseMessage = await _client.GetAsync("https://localhost:7211/api/manuels/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateManuelDto>(jsonData);
                return View(values);
            }

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateManuel(UpdateManuelDto updateManuelDto)
        {
            var content = JsonConvert.SerializeObject(updateManuelDto);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PutAsync("https://localhost:7211/api/manuels", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
