// Das Projekt wurde weitgehend unverändert übernommen von:
// https://docs.microsoft.com/en-us/ef/core/get-started/overview/first-app

using System;
using System.Linq;

namespace EFGetStarted {
    internal class Program {
        private static void Main() {
            using var context = new BloggingContext();
                // Damit das Programm ausgeführt werden kann, muss die Datenbank EFGetStarted
                // mit den Tabellen Blogs und Posts existieren.
                // Zum Erstellen per Migration taugen die folgenden PMC-Kommandos:
                // Add-Migration InitialCreate
                // Update-Database

                // Create
                Console.WriteLine("Inserting a new blog");
                context.Add(new Blog { Url = "http://blogs.msdn.com/adonet/" });
                context.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = context.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet/";
                //blog.Posts = new List<Post>();
                blog.Posts.Add(
                    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
                context.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");
                context.Remove(blog);
                context.SaveChanges();
        }
    }
}