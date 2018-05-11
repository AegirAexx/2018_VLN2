using System;
using System.Collections.Generic;
using System.Linq;
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

            int n = books.Count;
            Random rnd = new Random();
            while (n > 1) {
                int k = (rnd.Next(0, n) % n);
                n--;
                BookListViewModel value = books[k];
                books[k] = books[n];
                books[n] = value;
            }
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

       public List<BookListViewModel> SearchBooks(string lowerCaseTitle)
       {
           var bookSearch = _bookRepo.SearchBooks(lowerCaseTitle);
           return bookSearch;
       }

       public List<BookListViewModel> BooksAlphabet()
       {
            var booksAlphaOrder = _bookRepo.BooksAlphabet();
            return booksAlphaOrder;
       }

        public BookDetailsViewModel BookDetails(int id)
        {
            var bookDetails = _bookRepo.BookDetails(id);
            
            return bookDetails;
        }

        public FrontPageViewModel GetHomeBooks()
        {
            var homePageList = _bookRepo.GetHomeBooks();
            
            return homePageList;
        }
    }
}