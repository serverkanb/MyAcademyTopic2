using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.DataAccessLayer.Concrete;
using Topic.EntityLayer.Entities;

namespace Topic.BusinessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
    

            List<Blog> TGetBlogsWithCategories();

            List<Blog> TGetBlogsByCategoryId(int id);

            Blog TGetBlogWithCategoryById(int id);

            int TGetBlogCountByCategoryId(int categoryId);

        
    }
}
