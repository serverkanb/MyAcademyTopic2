using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.EntityLayer.Entities;

namespace Topic.DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetBlogsWithCategories();

        Blog GetBlogWithCategoryById(int id);

        List<Blog> GetBlogsByCategoryId(int id);

    }
}
