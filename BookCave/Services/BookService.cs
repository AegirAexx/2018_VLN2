using System.Collections.Generic;
using BookCave.Data.EntityModels;
using BookCave.Models.InputModels;
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

        public void AddComment(CommentInputModel inputComment, string currentUser)
        {
            var commentToAdd = new Comment
                                { 
                                    UserId = currentUser,
                                    BookId = inputComment.BookId,
                                    CommentText = inputComment.CommentText
                                };
            
            _bookRepo.AddComment(commentToAdd);
        }

        public void AddRating(int id, int rating)
        {
            //Byrja á að kalla á repo gera add to totalCount og totalRating, senda nidur bookId og rating
            _bookRepo.AddTotalRating(id, rating);

            //Kalla svo á repo á láta skila get á totalCount og total rating
            var totalRating = _bookRepo.GetTotalRating(id);
            var ratingCount = _bookRepo.GetRatingCount(id);

            //reikna svo út nýtt averageRating
            var newAverage = GetNewRating(totalRating, ratingCount);
            
            //Senda það svo ásamt bookId á repo til að gera update í grunninn
            _bookRepo.UpdateRating(id, newAverage);
        }

        public int GetNewRating(int totalRating, int ratingCount)
        {
            var newRating = totalRating / ratingCount;

            return newRating;
        }
    }
}