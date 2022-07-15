using System;
using System.Linq;

namespace SimpleQueries {
    internal class Program {
        private static void Main() {
            using var context = new BloggingContext();
            // Damit das Programm ausgeführt werden kann, muss die Datenbank EFGetStarted
            // mit den Tabellen Blogs und Posts existieren.
            // Zum Erstellen per Migration taugen die folgenden PMC-Kommandos:
            // Add-Migration InitialCreate
            // Update-Database

            Console.WriteLine("Blogs-Zeile mit dem Schlüsselwert 2 abrufen");
            //var vsBlog = context.Blogs.FirstOrDefault(b => b.BlogId == 2);
            var vsBlog = context.Blogs.Find(2);
            if (vsBlog != null)
                Console.WriteLine(vsBlog.Url);

            Console.WriteLine("Blogs-Zeile mit dem kleinsten Schlüsselwert abrufen");
            var blog = context.Blogs
                .OrderBy(b => b.BlogId)
                .First();
            Console.WriteLine("Id: " + blog.BlogId + ", URL: " + blog.Url);

            Console.WriteLine("\nAlle Blogs abrufen");
            var blogs = context.Blogs.ToList();
            foreach (var e in blogs)
                Console.WriteLine("Id: " + e.BlogId + ", URL: " + e.Url);

            Console.WriteLine("\nAlle Blogs zu Java abrufen");
            var jBlogs = context.Blogs
                .Where(b => b.Url.Contains("java"))
                .ToList();
            foreach (var e in jBlogs)
                Console.WriteLine("Id: " + e.BlogId + ", URL: " + e.Url);
        }
    }
}