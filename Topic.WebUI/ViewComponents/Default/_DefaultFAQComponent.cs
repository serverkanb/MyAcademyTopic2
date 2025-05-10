using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            try
            {
                var response = await _client.GetAsync("FAQ");

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Error = $"API çağrısı başarısız: {(int)response.StatusCode} {response.ReasonPhrase}";
                    return View(new List<ResultFAQDto>());
                }

                var jsonData = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(jsonData))
                {
                    ViewBag.Error = "API'den gelen veri boş.";
                    return View(new List<ResultFAQDto>());
                }

                var values = JsonConvert.DeserializeObject<List<ResultFAQDto>>(jsonData);
                return View(values ?? new List<ResultFAQDto>());
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Bir hata oluştu: " + ex.Message;
                return View(new List<ResultFAQDto>());
            }
        }
    }
}
