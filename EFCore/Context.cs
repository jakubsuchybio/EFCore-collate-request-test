using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
    public class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(x => Debug.WriteLine(x))
                .EnableSensitiveDataLogging()
                .UseSqlServer(@"Server=.\;Database=EFCoreDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}