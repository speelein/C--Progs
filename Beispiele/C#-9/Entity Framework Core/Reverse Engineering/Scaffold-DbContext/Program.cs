using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Reverse_Engineering {
    class Program {
        static void Main() {
            using NorthwindContext context = new();

            var custColl = context.Customers
                            .Where(c => c.Country == "Germany")
                            .Include(c => c.Orders)
                            .ToList();

            foreach (var c in custColl) {
                Console.WriteLine(c.CustomerId + " " + c.CompanyName);
                foreach (var ord in c.Orders)
                    Console.WriteLine(" " + ord.OrderDate);
            }
        }
    }
}
