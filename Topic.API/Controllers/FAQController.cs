using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinessLayer.Abstract;
using Topic.DTOLayer.Dtos.FAQ;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        private readonly IFAQService _faqService;
        private readonly IMapper _mapper;

        public FAQController(IFAQService faqService, IMapper mapper)
        {
            _faqService = faqService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var values = _faqService.TGetList();
            return Ok(_mapper.Map<List<ResultFAQDto>>(values));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _faqService.TGetById(id);
            return Ok(_mapper.Map<ResultFAQDto>(value));
        }

        [HttpPost]
        public IActionResult Create(CreateFAQDto dto)
        {
            var faq = _mapper.Map<FAQ>(dto);
            _faqService.TCreate(faq);
            return Ok("Soru başarıyla eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateFAQDto dto)
        {
            var faq = _mapper.Map<FAQ>(dto);
            _faqService.TUpdate(faq);
            return Ok("Soru başarıyla güncellendi");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _faqService.TDelete(id);
            return Ok("Soru silindi");
        }
    }
}
