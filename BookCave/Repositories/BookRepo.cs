using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;
using BookCave.Models.InputModels;

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
                            Title = b.Title,
                            Rating = b.Rating,
                            ISBN13 = b.ISBN13,
                            Author = b.Author
                        }).Take(32).ToList();
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
                            ISBN13 = b.ISBN13,
                            Author = b.Author
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
                            Rating = b.Rating,
                            ISBN13 = b.ISBN13,
                            Author = b.Author
                        }).ToList();
           return bookSearch;
       }

       public List<BookListViewModel> BooksAlphabet()
       {
           var booksAlphaOrder = (from b in _db.Books
                                orderby b.Title
                                select new BookListViewModel
                                {
                                    Id = b.Id,
                                    Title = b.Title,
                                    Rating = b.Rating,
                                    ISBN13 = b.ISBN13,
                                    Author = b.Author
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
                                    ISBN13 = b.ISBN13,
                                    Publisher = b.Publisher,
                                    PageCount = b.PageCount,
                                    YearPublished = b.YearPublished,
                                    OriginalPublicationYear = b.OriginalPublicationYear,
                                    Rating = b.Rating,
                                    Genre = b.Genre,
                                    Price = b.Price,
                                    Comments = (from c in _db.Comments
                                                    where c.BookId == id
                                                    select new Comment
                                                    {
                                                        Id = c.Id, 
                                                        UserId = (from u in _db.AspNetUsers
                                                                    where u.Id == c.UserId
                                                                    select u.Email).SingleOrDefault(),
                                                        BookId = c.BookId,
                                                        CommentText = c.CommentText
                                                    }).ToList()
                                }).SingleOrDefault();
            
            return bookDetails;
        }

        public FrontPageViewModel GetHomeBooks()
        {
            var homePageList = new FrontPageViewModel
                                {
                                    SciFi = (from b in _db.Books
                                            where b.Genre == "Science Fiction"
                                            select new BookDetailsViewModel
                                            {
                                                Id = b.Id,
                                                GoodReadsId = b.GoodReadsId,
                                                Title = b.Title,
                                                Author = b.Author,
                                                ISBN13 = b.ISBN13,
                                                Publisher = b.Publisher,
                                                PageCount = b.PageCount,
                                                YearPublished = b.YearPublished,
                                                OriginalPublicationYear = b.OriginalPublicationYear,
                                                Rating = b.Rating,
                                                Genre = b.Genre,
                                                Price = b.Price
                                            }).ToList(),
                                    Children = (from b in _db.Books
                                            where b.Genre == "Children"
                                            select new BookDetailsViewModel
                                            {
                                                Id = b.Id,
                                                GoodReadsId = b.GoodReadsId,
                                                Title = b.Title,
                                                Author = b.Author,
                                                ISBN13 = b.ISBN13,
                                                Publisher = b.Publisher,
                                                PageCount = b.PageCount,
                                                YearPublished = b.YearPublished,
                                                OriginalPublicationYear = b.OriginalPublicationYear,
                                                Rating = b.Rating,
                                                Genre = b.Genre,
                                                Price = b.Price
                                            }).ToList(),
                                    Contemporary = (from b in _db.Books
                                            where b.Genre == "Contemporary"
                                            select new BookDetailsViewModel
                                            {
                                                Id = b.Id,
                                                GoodReadsId = b.GoodReadsId,
                                                Title = b.Title,
                                                Author = b.Author,
                                                ISBN13 = b.ISBN13,
                                                Publisher = b.Publisher,
                                                PageCount = b.PageCount,
                                                YearPublished = b.YearPublished,
                                                OriginalPublicationYear = b.OriginalPublicationYear,
                                                Rating = b.Rating,
                                                Genre = b.Genre,
                                                Price = b.Price
                                            }).ToList(),
                                    Fantasy = (from b in _db.Books
                                            where b.Genre == "Fantasy"
                                            select new BookDetailsViewModel
                                            {
                                                Id = b.Id,
                                                GoodReadsId = b.GoodReadsId,
                                                Title = b.Title,
                                                Author = b.Author,
                                                ISBN13 = b.ISBN13,
                                                Publisher = b.Publisher,
                                                PageCount = b.PageCount,
                                                YearPublished = b.YearPublished,
                                                OriginalPublicationYear = b.OriginalPublicationYear,
                                                Rating = b.Rating,
                                                Genre = b.Genre,
                                                Price = b.Price
                                            }).ToList(),
                                    YoungAdult = (from b in _db.Books
                                            where b.Genre == "Young Adult"
                                            select new BookDetailsViewModel
                                            {
                                                Id = b.Id,
                                                GoodReadsId = b.GoodReadsId,
                                                Title = b.Title,
                                                Author = b.Author,
                                                ISBN13 = b.ISBN13,
                                                Publisher = b.Publisher,
                                                PageCount = b.PageCount,
                                                YearPublished = b.YearPublished,
                                                OriginalPublicationYear = b.OriginalPublicationYear,
                                                Rating = b.Rating,
                                                Genre = b.Genre,
                                                Price = b.Price
                                            }).ToList()
                                };
            
            return homePageList;
        }
        public void AddComment(Comment commentToAdd)
        {
            _db.Comments.Add(commentToAdd);
            _db.SaveChanges(); 
        }

        public void AddTotalRating(int id, int rating)
        {
            var bookToUpdate = (from b in _db.Books
                                where b.Id == id
                                select b).SingleOrDefault();
            
            bookToUpdate.RatingCount += 1;
            bookToUpdate.RatingTotal += rating;
            _db.SaveChanges();
        }

        public int GetTotalRating(int id)
        {
            var totalRating = (from b in _db.Books
                                where b.Id == id
                                select b.RatingTotal).SingleOrDefault();
            return totalRating;
        }

        public int GetRatingCount(int id)
        {
            var ratingCount = (from b in _db.Books
                                where b.Id == id
                                select b.RatingCount).SingleOrDefault();
            return ratingCount;
        }

        public void UpdateRating(int id, int newAverage)
        {

            var bookToUpdate = (from b in _db.Books
                                where b.Id == id
                                select b).SingleOrDefault();
            
            bookToUpdate.Rating = newAverage;
            _db.SaveChanges();
        }
    }

}