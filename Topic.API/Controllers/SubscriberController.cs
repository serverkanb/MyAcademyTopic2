using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinessLayer.Abstract;
using Topic.DTOLayer.Dtos.SubscriberDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {

        private readonly ISubscriberService _subscriberService;
        private readonly IMapper _mapper;

        public SubscriberController(IMapper mapper, ISubscriberService subscriberService)
        {
            _mapper = mapper;
            _subscriberService = subscriberService;
        }

        [HttpPost]
        public IActionResult AddSubscriber(CreateSubscriberDto dto)
        {
            var subscriber = _mapper.Map<Subscriber>(dto);
            _subscriberService.TCreate(subscriber);
            return Ok("Abonelik başarılı.");
        }
    }
}
