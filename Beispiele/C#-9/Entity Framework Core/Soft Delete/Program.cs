using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SoftDelete {
    internal class Program {
        private static void Main() {
            using var context = new BloggingContext();
            // Damit das Programm ausgeführt werden kann, muss die Datenbank SoftDelete
            // mit den Tabellen Blogs und Posts existieren.
            // Zum Erstellen per Migration taugen die folgenden PMC-Kommandos:
            // Add-Migration InitialCreate
            // Update-Database

            var jBlog = context.Blogs
                .Where(b => b.Url.Contains("java"))
                .Include(b => b.Posts)
                .FirstOrDefault();
            Console.WriteLine("Posts im Java-Blog:");
            foreach (var p in jBlog.Posts)
                Console.WriteLine(p.Title);
        }
    }
}