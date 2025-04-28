using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Topic.BusinessLayer.Abstract;
using Topic.DTOLayer.Dtos.BlogDtos;
using Topic.EntityLayer.Entities;

namespace Topic.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

       

        public BlogsController(IBlogService blogService, IMapper mapperService)
        {
            _blogService = blogService;
            _mapper = mapperService;
        }

        [HttpGet]
        public IActionResult GetAllBlogs()
        {
            var values = _blogService.TGetBlogsWithCategories();
            var blogs = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(blogs);
        }

        [HttpGet("GetBlogsByCategoryId/{id}")]
        public IActionResult GetBlogsByCategoryId(int id)
        {
            var values = _blogService.TGetBlogsByCategoryId(id);
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlogById(int id)
        {
            var value = _blogService.TGetBlogWithCategoryById(id);
            var blog = _mapper.Map<ResultBlogDto>(value);
            return Ok(blog);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            _blogService.TDelete(id);
            return Ok("Blog başarıyla silindi");
        }

        [HttpPost]
        public IActionResult CreateBlog(CreateBlogDto createBlogDto)
        {
            var blog = _mapper.Map<Blog>(createBlogDto);
            _blogService.TCreate(blog);
            return Ok("Blog başarıyla oluşturuldu");
        }

        [HttpPut]
        public IActionResult UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            var blog = _mapper.Map<Blog>(updateBlogDto);
            _blogService.TUpdate(blog);
            return Ok("Blog başarıyla güncellendi");
        }

    }

}
