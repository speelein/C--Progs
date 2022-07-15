using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SimpleQueries {
    public class BloggingContext : DbContext {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer("Server=tcp:bernhard\\SQLEXPRESS; " +
                "Initial Catalog=EFGetStarted; Integrated Security=true;");
            //options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; " +
            //"Initial Catalog=EFGetStarted; Integrated Security=true;");
        }
    }

    public class Blog {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }

    public class Post {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}