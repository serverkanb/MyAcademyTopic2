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


        [HttpGet("Paged")]
        public IActionResult GetPagedBlogs([FromQuery] int page = 1, [FromQuery] int pageSize = 5, [FromQuery] string keyword = "")
        {
            var allBlogs = _blogService.TGetBlogsWithCategories();

            if (!string.IsNullOrEmpty(keyword))
            {
                keyword = keyword.ToLower();
                allBlogs = allBlogs
                    .Where(b =>
                        (!string.IsNullOrEmpty(b.Title) && b.Title.ToLower().Contains(keyword)) ||
                        (!string.IsNullOrEmpty(b.LongDescription) && b.LongDescription.ToLower().Contains(keyword))
                    )
                    .ToList();
            }

            var totalCount = allBlogs.Count;
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            var pagedBlogs = allBlogs
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var blogs = _mapper.Map<List<ResultBlogDto>>(pagedBlogs);

            var result = new PagedResultDto<ResultBlogDto>
            {
                Items = blogs,
                TotalPages = totalPages
            };

            return Ok(result);
        }

    }
}