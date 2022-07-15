using System;

namespace TphMultilevel {
    internal class Program {
        private static void Main() {
            using (var context = new BloggingContext()) {
                Blog b = new() { Url = "http://blogs.msdn.com/adonet/" };
                context.Add(b);
                RssBlog rb = new() { Url = "https://www.microsoft.com/de-de/techwiese/default.aspx",
                                     RssUrl = "https://www.microsoft.com/de-de/techwiese/feeds/rss/aktuell.xml" };
                context.Add(rb);
                RssBlogEx rbex = new() { Url = "https://www.microsoft.com/de-de/techwiese/default.aspx",
                                         RssUrl = "https://www.microsoft.com/de-de/techwiese/feeds/rss/aktuell.xml",
                                         Rating = 3};
                context.Add(rbex);
                context.SaveChanges();
            }
        }
    }
}