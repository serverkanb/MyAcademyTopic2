﻿using AutoMapper;
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
        [HttpGet]
        public IActionResult SubscriberList()
        {
            var values = _subscriberService.TGetList();
            return Ok(values);

        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _subscriberService.TGetById(id);
            if (value == null)
                return NotFound("Abone bulunamadı.");
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubscriber(int id)
        {
            var subscriber = _subscriberService.TGetById(id);
            if (subscriber == null)
                return NotFound("Abone bulunamadı.");

            _subscriberService.TDelete(id);
            return Ok("Abone silindi.");
        }


        [HttpPost]
        public IActionResult AddSubscriber(CreateSubscriberDto dto)
        {
            // Model geçerli mi?
            if (!ModelState.IsValid)
            {
                return BadRequest("Lütfen geçerli veriler girin.");
            }

            // Bu e-posta zaten abone mi?
            if (_subscriberService.TGetList().Any(x => x.Email == dto.Email))
            {
                return BadRequest("Bu e-posta adresi zaten kayıtlı.");
            }

            // Map ve kayıt işlemi için
            var subscriber = _mapper.Map<Subscriber>(dto);
            subscriber.Role = "USER";
            _subscriberService.TCreate(subscriber);

            return Ok("Abonelik başarılı.");
        }
        [HttpPut]
        public IActionResult UpdateSubscriber(UpdateSubscriberDto dto)
        {
            var value = _subscriberService.TGetById(dto.SubscriberId);
            if (value == null)
                return NotFound("Güncellenecek abone bulunamadı.");

            var updated = _mapper.Map<Subscriber>(dto);
            _subscriberService.TUpdate(updated);
            return Ok("Abone bilgileri güncellendi.");
        }

    }
}
