using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Data;
using System.Text;
using Topic.WebUI.Dtos.BlogDtos;

using Topic.WebUI.Dtos.BlogDtos;
using Topic.WebUI.Dtos.CategoryDtos;


namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    [Authorize(Roles = "ADMIN")]
    public class BlogController : Controller
    {
        private readonly HttpClient _client;

        public BlogController(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7211/api/");
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync("blogs");
            if (!response.IsSuccessStatusCode)
                return View(new List<ResultBlogDto>());

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBlogDto>>(json);
            return View(values);
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _client.DeleteAsync($"blogs/{id}");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            var response = await _client.GetAsync("categories");
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Categories = new List<SelectListItem>();
                return View();
            }

            var json = await response.Content.ReadAsStringAsync();
            var categoryList = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(json);

            ViewBag.Categories = categoryList.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            var jsonData = JsonConvert.SerializeObject(createBlogDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("blogs", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            var blogResponse = await _client.GetAsync($"blogs/{id}");
            var categoryResponse = await _client.GetAsync("categories");

            if (!blogResponse.IsSuccessStatusCode || !categoryResponse.IsSuccessStatusCode)
                return RedirectToAction("Index");

            var blogJson = await blogResponse.Content.ReadAsStringAsync();
            var blog = JsonConvert.DeserializeObject<UpdateBlogDto>(blogJson);

            var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
            var categoryList = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJson);

            ViewBag.Categories = categoryList.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryId.ToString()
            }).ToList();

            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            var jsonData = JsonConvert.SerializeObject(updateBlogDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync("blogs", content);
            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(updateBlogDto);
        }
    }
}
