using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    [Authorize(Roles = "ADMIN")]
    public class CategoryController : Controller
    {
        private readonly HttpClient _client;

        public CategoryController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {

            var responseMessage = await _client.GetAsync("https://localhost:7211/api/categories");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            //nesneyi Json stringe çevirir
            var category = JsonConvert.SerializeObject(createCategoryDto);
            //Json Stringi httpcontent formatına çevirir,utf8 karakter seri belirlenir
            var stringContent = new StringContent(category, Encoding.UTF8, "application/json");
            //oluşturulan string contenti gönderir
            var responseMessage = await _client.PostAsync("https://localhost:7211/api/categories", stringContent);
            //apiden dönen yanıt kontrolü
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var responseMessage = await _client.DeleteAsync("https://localhost:7211/api/categories/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var responseMessage = await _client.GetAsync("https://localhost:7211/api/categories/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                //Json cevabını string olrak al
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //JSON → UpdateCategoryDto nesnesine dönüştür
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            
            var category = JsonConvert.SerializeObject(updateCategoryDto);

            var stringContent = new StringContent(category, Encoding.UTF8, "application/json");
           // API’ya PUT isteği atılır(güncelleme için)
            var responseMessage = await _client.PutAsync("https://localhost:7211/api/categories", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
