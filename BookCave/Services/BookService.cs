using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class BookService
    {
        private BookRepo _bookRepo;

        public BookService()
        {
            _bookRepo = new BookRepo();
        }

       public List<BookListViewModel> GetAllBooks()
       {
           var books = _bookRepo.GetAllBooks();

           return books;
       }

       public List<BookListViewModel> TopTenBooks()
       {
           var topten = _bookRepo.TopTenBooks();
           return topten;
       }

       public List<BookListViewModel> GetGenre(string genre)
       {
           var genreView = _bookRepo.GetGenre(genre);
           return genreView;
       }
    }
}