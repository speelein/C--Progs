using System;
using System.Linq;

namespace SimpleQueries {
    internal class Program {
        private static void Main() {
            using (var db = new BloggingContext()) {
                // Damit das Programm ausgeführt werden kann, muss die Datenbank EFGetStarted
                // mit den Tabellen Blogs und Posts existieren.
                // Zum Erstellen per Migration taugen die folgenden PMC-Kommandos:
                // Add-Migration InitialCreate
                // Update-Database

                //Console.WriteLine("Alle Posts und Blogs löschen");
                //var posts = from p in db.Posts select p;
                //db.Posts.RemoveRange(posts);
                //var blogs = from b in db.Blogs select b;
                //db.Blogs.RemoveRange(blogs);
                //int deleted = db.SaveChanges();
                //Console.WriteLine("Gelöschte Zeilen: " + deleted);

                //Console.WriteLine("\nNeue Blogs einfügen");
                //db.Add(new Blog { Url = "http://blogs.msdn.com/adonet/" });
                //db.Add(new Blog { Url = "https://devblogs.microsoft.com/visualstudio/" });
                //db.Add(new Blog { Url = "https://devblogs.microsoft.com/aspnet/" });
                //db.Add(new Blog { Url = "https://devblogs.microsoft.com/java/" });
                //db.Add(new Blog { Url = "https://devblogs.microsoft.com/xamarin/" });
                //db.Add(new Blog { Url = "https://devblogs.microsoft.com/math-in-office/" });
                //int changed = db.SaveChanges();
                //Console.WriteLine("Ergänzte Zeilen: " + changed);

                Console.WriteLine("\nAlle Blogs zu Java abrufen");
                var jBlogs = db.Blogs
                    .AsEnumerable()
                    .Where(b => b.Url.Contains("java"));
                foreach (var e in jBlogs)
                    Console.WriteLine("Id: " + e.BlogId + ", URL: " + e.Url);
            }
        }
    }
}