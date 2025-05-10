using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinessLayer.Abstract;
using Topic.DataAccessLayer.Abstract;
using Topic.DTOLayer.Dtos.CategoryDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper, IBlogService blogService = null)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _blogService = blogService;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var values = _categoryService.TGetList();
            var categories = _mapper.Map<List<ResultCategoryDto>>(values);
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id)
        {
            var value = _categoryService.TGetById(id);
            var category = _mapper.Map<ResultCategoryDto>(value);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);
            return Ok("Kategori Başarıyla Silindi");
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TCreate(category);
            return Ok("Kategori Başarıyla Oluşturuldu");
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var category = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(category);
            return Ok("Kategori Başarıyla Güncellendi");
        }

        [HttpGet("GetActiveCategories")]

        public IActionResult GetActiveCategories()
        {
            //statusu true olanları getir dedik
            var values = _categoryService.TGetActiveCategories();
            var mappedResult = _mapper.Map<List<ResultCategoryDto>>(values);
            return Ok(mappedResult);
        }

        [HttpGet("GetBlogCountByCategoryId/{id}")]
        public IActionResult GetBlogCountByCategoryId(int id)
        {
            var blogCount = _blogService.TGetBlogCountByCategoryId(id);
            return Ok(blogCount);
        }


    }
}
