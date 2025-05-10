using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Topic.WebUI.Dtos.BlogDtos;

namespace Topic.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _client;

        public BlogController(HttpClient client)
        {
           
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
           
            return View();
        }


        public async Task<IActionResult> GetBlogsByCategory(int id)
        {

            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("https://localhost:7211/api/blogs/GetBlogsByCategoryId/" + id);

            return View(values);
        }


        public async Task<IActionResult> GetBlogDetails(int id)
        {
            var value = await _client.GetFromJsonAsync<ResultBlogDto>("https://localhost:7211/api/blogs/" + id);
            return View(value);
        }

        public async Task<IActionResult> GetAllBlogs(string keyword = "", int page = 1)
        {
            var url = $"https://localhost:7211/api/blogs/paged?page={page}&pageSize=5";

            if (!string.IsNullOrEmpty(keyword))
            {
                url += $"&keyword={Uri.EscapeDataString(keyword)}";
            }

            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View(new List<ResultBlogDto>());

            var jsonData = await response.Content.ReadAsStringAsync();
            var pagedResult = JsonConvert.DeserializeObject<PagedResultDto<ResultBlogDto>>(jsonData);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = pagedResult.TotalPages;
            ViewBag.Keyword = keyword;

            return View(pagedResult.Items);
        }

        

    }
}
