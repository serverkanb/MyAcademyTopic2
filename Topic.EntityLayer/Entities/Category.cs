using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic.EntityLayer.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public bool Status { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}
