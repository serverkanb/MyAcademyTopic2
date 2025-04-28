using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topic.EntityLayer.Entities;

namespace Topic.DataAccessLayer.Context
{
    public class TopicContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-1IHFPICF;database=MyTopicDb;trusted_connection=true;multipleactiveresultsets=true;trustservercertificate=true;");
        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Manuel> Manuels { get; set; }
    }


}
