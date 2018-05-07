using BookCave.Data.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace BookCave.Data
{
    public class DataContext : DbContext
    {
        ///public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
              .UseSqlServer(
                "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H12;Persist Security Info=False;User ID=VLN2_2018_H12_usr;Password=slimySumm3r47;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30"
              );
        }
    }
}