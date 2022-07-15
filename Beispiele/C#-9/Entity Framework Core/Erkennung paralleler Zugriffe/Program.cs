using System;
using System.Linq;

namespace Zugriffskonflikte {
    class Program {
        private static void Main() {
            using (var context = new BloggingContext()) {
                // Damit das Programm ausgeführt werden kann, muss die Datenbank Konflikte
                // mit der Tabelle Blogs und Posts existieren.
                // Zum Erstellen per Migration taugen die folgenden PMC-Kommandos:
                // Add-Migration InitialCreate
                // Update-Database

                // Konflikterkennung
                Console.WriteLine("Querying for a blog");
                var blog = context.Blogs
                    .Where(b => b.Url == "https://devblogs.microsoft.com/adonet/")
                    .Single();
                Console.WriteLine("Parallele Änderung des Blogs in der Datenbank vornehmen, Enter.");
                Console.ReadLine();

                Console.WriteLine("Try to update the blog");
                blog.Rating = 3;
                try {
                    context.SaveChanges();
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}