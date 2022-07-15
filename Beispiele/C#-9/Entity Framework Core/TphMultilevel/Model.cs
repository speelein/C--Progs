using Microsoft.EntityFrameworkCore;

namespace TphMultilevel {
    class BloggingContext : DbContext {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<RssBlog> RssBlogs { get; set; }
        public DbSet<RssBlogEx> RssExBlogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer("Server=tcp:bernhard\\SQLEXPRESS; " +
                "Initial Catalog=TphMultilevel; Integrated Security=true;");
        }
    }

    public class Blog {
        public int BlogId { get; set; }
        public string Url { get; set; }
    }

    public class RssBlog : Blog {
        public string RssUrl { get; set; }
    }

    public class RssBlogEx : RssBlog {
        public int Rating { get; set; }
    }
}