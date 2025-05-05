using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.FAQ;


namespace Topic.WebUI.ViewComponents.Default
{
    public class _DefaultFAQComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _DefaultFAQComponent(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:7211/api/");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var response = await _client.GetAsync("faqs");
            if (!response.IsSuccessStatusCode)
            {
                return View(new List<ResultFAQDto>());
            }

            var jsonData = await response.Content.ReadAsStringAsync();
            var values = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResultFAQDto>>(jsonData);
            return View(values);
        }
    }
}
