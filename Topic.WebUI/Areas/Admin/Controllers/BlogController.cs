using Microsoft.AspNetCore.Mvc;

using Topic.WebUI.Dtos.BlogDtos;

using Topic.WebUI.Dtos.BlogDtos;
using Topic.WebUI.Dtos.CategoryDtos;
using Topic.WebUI.Service;

namespace Topic.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BlogController(IBlogService _blogService) : Controller
    {


        public async Task<IActionResult> Index()
        {
            var values = await _blogService.GetAllAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _blogService.DeleteBlogAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            await _blogService.CreateBlogAsync(createBlogDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {

            var values = await _blogService.GetByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            await _blogService.UpdateBlogAsync(updateBlogDto);
            return RedirectToAction("Index");
        }
    }
}
