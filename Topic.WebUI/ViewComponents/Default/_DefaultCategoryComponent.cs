using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.CategoryDtos;

namespace Topic.WebUI.ViewComponents.Default
{
    public class _DefaultCategoryComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _DefaultCategoryComponent(HttpClient client)
        {
            _client = client;
            client.BaseAddress = new Uri("https://localhost:7211/api/");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCategoryDto>>("https://localhost:7211/api/categories/GetActiveCategories");

            foreach (var category in values)
            {
                var response = await _client.GetAsync($"blogs/GetBlogCountByCategoryId/{category.CategoryId}");
                if (response.IsSuccessStatusCode)
                {
                    var count = await response.Content.ReadAsStringAsync();
                    category.BlogCount = int.Parse(count); 
                }
            }
            
            return View(values);
        }


    }
}