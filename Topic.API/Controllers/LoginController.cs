using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinessLayer.Abstract;
using Topic.DTOLayer.Dtos.LoginDtos;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ISubscriberService _subscriberService;

        public LoginController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginDto dto)
        {
            var user = _subscriberService.TGetList()
                .FirstOrDefault(x => x.Email == dto.Email && x.Password == dto.Password);

            if (user == null)
                return Unauthorized("Giriş bilgileri hatalı!");

            return Ok(new
            {
                user.Email,
                user.Role
            });
        }
    }

}
