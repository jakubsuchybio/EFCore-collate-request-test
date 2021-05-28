using System;
using System.Linq;
using EFCore;
using Microsoft.EntityFrameworkCore;

namespace EfCore
{
    public static class Program
    {
        public static void Main()
        {
            using (var context = new Context())
            {
                // var book1 = new Book { Title = "Píča" };
                // var book2 = new Book { Title = "čůRák" };
                // var book3 = new Book { Title = "MacBeth" };
                //
                // context.Add(book1);
                // context.Add(book2);
                // context.Add(book3);
                // context.SaveChanges();

                var pica = context.Books
                    .Where(x => EF.Functions.Collate(x.Title, "latin1_general_ci_ai") == "piCa")
                    .ToArray();

                Console.WriteLine($"Found {pica.Length} items.");
                if (pica.Any())
                {
                    var picaBook = pica.First();
                    Console.WriteLine($"Found book {picaBook.Title}");
                }
            }

            Console.WriteLine("End!");
        }
    }
}