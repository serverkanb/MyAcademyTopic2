using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Topic.WebUI.Dtos.ContactDto;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    [Authorize(Roles = "ADMIN")]
    public class ContactController : Controller
    {
        private readonly HttpClient _client;

        public ContactController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _client.GetAsync("https://localhost:7211/api/contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            var contact = JsonConvert.SerializeObject(createContactDto);
            var stringContent = new StringContent(contact, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PostAsync("https://localhost:7211/api/contact", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            var responseMessage = await _client.DeleteAsync("https://localhost:7211/api/contact/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var responseMessage = await _client.GetAsync("https://localhost:7211/api/contact/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
                return View(values);
            }
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            var contact = JsonConvert.SerializeObject(updateContactDto);
            var stringContent = new StringContent(contact, Encoding.UTF8, "application/json");
            var responseMessage = await _client.PutAsync("https://localhost:7211/api/contact", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
