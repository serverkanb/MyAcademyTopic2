using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.DataAccessLayer.Abstract;
using Topic.DataAccessLayer.Context;
using Topic.DataAccessLayer.Repositories;
using Topic.EntityLayer.Entities;

namespace Topic.DataAccessLayer.Concrete
{
    public class EfBlogDal : GenericRepository<Blog>, IBlogDal
    {
        public EfBlogDal(TopicContext context) : base(context)
        {
        }
        public List<Blog> GetBlogsByCategoryId(int id)
        {
            return _context.Blogs.Where(x => x.CategoryId == id).ToList();
        }

        public List<Blog> GetBlogsWithCategories()
        {
            return _context.Blogs.Include(x => x.Category).ToList();
        }

        public Blog GetBlogWithCategoryById(int id)
        {
            return _context.Blogs.Include(x => x.Category).FirstOrDefault(x => x.BlogId == id);
        }
    }
}
