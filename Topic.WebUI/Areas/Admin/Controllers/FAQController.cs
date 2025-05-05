using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Topic.WebUI.Dtos.FAQ;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class FAQController : Controller
    {
        private readonly HttpClient _client;

        public FAQController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _client.GetAsync("https://localhost:7211/api/faqs");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFAQDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateFaq()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFaq(CreateFAQDto createFaqDto)
        {
            var faq = JsonConvert.SerializeObject(createFaqDto);
            var stringContent = new StringContent(faq, Encoding.UTF8, "application/json");

            var responseMessage = await _client.PostAsync("https://localhost:7211/api/faqs", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DeleteFaq(int id)
        {
            var responseMessage = await _client.DeleteAsync("https://localhost:7211/api/faqs/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFaq(int id)
        {
            var responseMessage = await _client.GetAsync("https://localhost:7211/api/faqs/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFAQDto>(jsonData);
                return View(values);
            }
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFaq(UpdateFAQDto updateFaqDto)
        {
            var faq = JsonConvert.SerializeObject(updateFaqDto);
            var stringContent = new StringContent(faq, Encoding.UTF8, "application/json");

            var responseMessage = await _client.PutAsync("https://localhost:7211/api/faqs", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
