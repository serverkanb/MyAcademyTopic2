using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using Topic.WebUI.Dtos.ManuelDtos;
using Topic.WebUI.Dtos.SubscriberDtos;

namespace Topic.WebUI.ViewComponents.Default
{
    public class _DefaultSubscriberComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(new CreateSubscriberDto());
        }
    }

}
