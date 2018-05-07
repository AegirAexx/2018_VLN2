using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookCave.Data;
using BookCave.Data.EntityModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BookCave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            ///SeedData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
        
        public static void SeedData()
        {
            var db = new DataContext();

            ///Þetta er if guard sem kemur i veg fyrir ad appendast
            if(!db.Books.Any())
            {
                var initialBooks = new List<Book>()
                {
                    new Book { Title = "Ready Player One" },
                    new Book { Title = "Harry Potter" },
                    new Book { Title = "50 Shades Of Black" }
                };

                db.AddRange(initialBooks);
                db.SaveChanges();
            }
        }
    }
}
