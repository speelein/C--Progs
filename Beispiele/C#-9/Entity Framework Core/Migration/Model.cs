using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted {
    public class BloggingContext : DbContext {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer("Server=tcp:bernhard\\SQLEXPRESS; " +
                "Initial Catalog=EFGetStarted; Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Blog>().HasData(
                new Blog {
                    BlogId = 1,
                    Url = "https://devblogs.microsoft.com/aspnet/",
                    Rating = 3
                },
                new Blog {
                    BlogId = 2,
                    Url = "https://devblogs.microsoft.com/visualstudio/",
                    Rating = 2
                }
            );
            modelBuilder.Entity<Post>().HasData(
                new Post {
                    PostId = 1,
                    BlogId = 2,
                    Title = "New in 2019 16.11.2"
                },
                new Post {
                    PostId = 2,
                    BlogId = 2,
                    Title = "VS 2022 Preview"
                }
            );
        }
    }

    public class Blog {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }

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