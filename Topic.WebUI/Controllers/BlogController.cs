using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> GetBlogsByCategory(int id)
        {

            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs/GetBlogsByCategoryId/" + id);

            return View(values);
        }


        public async Task<IActionResult> GetBlogDetails(int id)
        {
            var value = await _client.GetFromJsonAsync<ResultBlogDto>("blogs" + id);
            return View(value);
        }
    }
}
