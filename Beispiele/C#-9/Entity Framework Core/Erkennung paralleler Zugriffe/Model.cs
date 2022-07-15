using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Zugriffskonflikte {
    public class BloggingContext : DbContext {
        public DbSet<Blog> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseSqlServer("Server=tcp:bernhard\\SQLEXPRESS; " +
                "Initial Catalog=Konflikte; Integrated Security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            //modelBuilder.Entity<Blog>()
            //    .Property(a => a.Url).IsConcurrencyToken();
            modelBuilder.Entity<Blog>()
            .Property<byte[]>("RowVersion")
            .IsRowVersion();

            modelBuilder.Entity<Blog>().HasData(
                new Blog {
                    BlogId = 1,
                    Url = "https://devblogs.microsoft.com/adonet/",
                    Rating = 2
                },
                new Blog {
                    BlogId = 2,
                    Url = "https://devblogs.microsoft.com/visualstudio/",
                    Rating = 1
                },
                new Blog {
                    BlogId = 3,
                    Url = "https://devblogs.microsoft.com/aspnet/",
                    Rating = 2
                }
            );
        }
    }

    public class Blog {
        public int BlogId { get; set; }
        //[ConcurrencyCheck]
        public string Url { get; set; }
        public int Rating { get; set; }
    }
}