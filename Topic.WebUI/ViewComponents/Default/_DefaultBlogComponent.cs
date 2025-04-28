using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.BlogDtos;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.ViewComponents.Default
{
    public class _DefaultBlogComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _DefaultBlogComponent(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost:7165/api/");
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("categories");

            ViewBag.categories = categories;

            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
            return View(values);
        }
    }
}
