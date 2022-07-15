using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFGetStarted {
    public class BloggingContext : DbContext {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            // Verbindungszeichenfolge aus appsettings.json lesen
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            options.UseSqlServer(config.GetConnectionString("EFGetStartedDb"));
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