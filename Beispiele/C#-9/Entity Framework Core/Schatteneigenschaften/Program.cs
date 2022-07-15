using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace SchattenUndKonflikte {
    internal class Program {
        private static void Main() {
            using (var context = new BloggingContext()) {
                // Damit das Programm ausgeführt werden kann, muss die Datenbank Schatten
                // mit der Tabelle Blogs und Posts existieren.
                // Zum Erstellen per Migration taugen die folgenden PMC-Kommandos:
                // Add-Migration InitialCreate
                // Update-Database

                //Blog erstellen
                //Console.WriteLine("Inserting a new blog");
                //Blog blog = new Blog { Url = "https://blogs.msdn.com/adonet/" };
                //context.Add(blog);
                //Post p = new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" };
                //blog.Posts.Add(p);
                //context.SaveChanges();
                //return;

                // Abfrage unter Verwendung einer Schatteneigenschaft
                Console.WriteLine("Query using a shadow property");
                var blogs = context.Blogs.OrderBy(b => EF.Property<DateTime>(b, "LastUpdated"));
                foreach (var b in blogs)
                    Console.WriteLine(b.BlogId);
            }
        }
    }
}