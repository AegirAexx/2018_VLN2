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

       public List<BookListViewModel> TopTenBooks()
       {
           var topten = (from b in _db.Books
                        orderby b.Rating descending
                        select new BookListViewModel
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Rating = b.Rating,
                            ISBN13 = b.ISBN13,
                            Author = b.Author
                        }).Take(10).ToList();

           return topten;
       }

        public List<BookListViewModel> GetGenre(string genre)
       {
           var genreView = (from b in _db.Books
                        where b.Genre == genre
                        select new BookListViewModel
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Rating = b.Rating,
                            Genre = b.Genre
                        }).ToList();

           return genreView;
       }

       public List<BookListViewModel> SearchBooks(string lowerCaseTitle)
       {
           var bookSearch = (from b in _db.Books
                        where b.Title.ToLower().Contains(lowerCaseTitle)
                        select new BookListViewModel
                        {
                            Id = b.Id,
                            Title = b.Title,
                        }).ToList();
           return bookSearch;
       }

       public List<BookListViewModel> BooksAlphabet()
       {
           var booksAlphaOrder = (from b in _db.Books
                                orderby b.Title
                                select new BookListViewModel
                                {
                                    Title = b.Title,
                                }).ToList();
           return booksAlphaOrder;
       }

        public BookDetailsViewModel BookDetails(int id)
        {
            var bookDetails = (from b in _db.Books
                                where b.Id == id
                                select new BookDetailsViewModel
                                {
                                    Id = b.Id,
                                    GoodReadsId = b.GoodReadsId, 
                                    Title = b.Title,
                                    Author = b.Author,
                                    ISBN = b.ISBN13,
                                    Publisher = b.Publisher,
                                    PageCount = b.PageCount,
                                    YearPublished = b.YearPublished,
                                    OriginalPublicationYear = b.OriginalPublicationYear,
                                    Rating = b.Rating,
                                    Genre = b.Genre,
                                    Price = b.Price
                                }).SingleOrDefault();
            
            return bookDetails;
        }
    }

}