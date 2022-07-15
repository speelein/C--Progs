using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SoftDelete {
    public class BloggingContext : DbContext {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer("Server=tcp:bernhard\\SQLEXPRESS; " +
                "Initial Catalog=SoftDelete; Integrated Security=true;");
            //options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; " +
            //"Initial Catalog=EFGetStarted; Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Blog>().HasData(
                new Blog {
                    BlogId = 1,
                    Url = "https://devblogs.microsoft.com/aspnet/"
                },
                new Blog {
                    BlogId = 2,
                    Url = "https://devblogs.microsoft.com/visualstudio/"
                },
                new Blog {
                    BlogId = 3,
                    Url = "https://devblogs.microsoft.com/java/"
                },
                new Blog {
                    BlogId = 4,
                    Url = "https://devblogs.microsoft.com/xamarin/"
                },
                new Blog {
                    BlogId = 5,
                    Url = "https://devblogs.microsoft.com/math-in-office/"
                }
            );
            modelBuilder.Entity<Post>().HasData(
                new Post {
                    PostId = 1,
                    BlogId = 3,
                    Title = "Post about Java",
                    IsDeleted = true
                }
            );
            modelBuilder.Entity<Post>().HasQueryFilter(p => !p.IsDeleted);
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
        public bool IsDeleted { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}