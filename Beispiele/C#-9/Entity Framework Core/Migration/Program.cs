using System;

namespace EFGetStarted {
    internal class Program {
        private static void Main() {
            using (var db = new BloggingContext()) {
                // Damit das Programm ausgeführt werden kann, muss die Datenbank EFGetStarted
                // mit den Tabellen Blogs und Posts existieren.
                // Das folgende Kommando wendet alle im Projekt enthaltenen Migrationen an:
                // Update-Database

                Console.WriteLine("Inserting a new blog");
                var blog = new Blog { Url = "https://devblogs.microsoft.com/xamarin/" };
                db.Add(blog);
                db.SaveChanges();
            }
        }
    }
}