using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinessLayer.Abstract;
using Topic.DTOLayer.Dtos.ContactDto;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var values = _contactService.TGetList();
            var result = _mapper.Map<List<ResultContactDto>>(values);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var value = _contactService.TGetById(id);
            var result = _mapper.Map<ResultContactDto>(value);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto dto)
        {
            var contact = _mapper.Map<Contact>(dto);
            _contactService.TCreate(contact);
            return Ok("İletişim bilgisi başarıyla eklendi.");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto dto)
        {
            var contact = _mapper.Map<Contact>(dto);
            _contactService.TUpdate(contact);
            return Ok("İletişim bilgisi başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            _contactService.TDelete(id);
            return Ok("İletişim bilgisi silindi.");
        }
    }
}
