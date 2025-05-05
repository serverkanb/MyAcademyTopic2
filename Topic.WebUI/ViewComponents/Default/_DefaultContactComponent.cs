using Microsoft.AspNetCore.Mvc;
using Topic.WebUI.Dtos.ContactDto;

namespace Topic.WebUI.ViewComponents.Default
{
    public class _DefaultContactComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _DefaultContactComponent(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://localhost:7211/api/");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contact");
            return View(values);
        }
    }
}
