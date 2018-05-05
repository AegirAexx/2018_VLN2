using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class BookRepo
    {
        private DataContext _db;

        public BookRepo()
        {
            _db = new DataContext();
        }

       public List<BookListViewModel> GetAllBooks()
       {
           var books = (from b in _db.Books
                        select new BookListViewModel
                        {
                           Id = b.Id,
                           Title = b.Title 
                        }).ToList();
           return books;
       }

    }
}