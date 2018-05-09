
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using BookCave.Models.InputModels;
using BookCave.Data.EntityModels;

namespace BookCave.Controllers
{
    public class HomeController : Controller
    {
        private BookService _bookService; // Read only?

        private OrderService _orderService; // Read only?

        public HomeController()
        {
            _bookService = new BookService();

            _orderService = new OrderService();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SeeBooks()
        {
            var books = _bookService.GetAllBooks();
            return View(books);
        }

        public IActionResult GetOrders()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }

        public IActionResult TopTenBooks()
        {
            var topten = _bookService.TopTenBooks();
            return View(topten);
        }

        public IActionResult Genre(string genre)
        {
            var genreView = _bookService.GetGenre(genre);
            return View(genreView);
        }
        public IActionResult Search(string x)
        {
             if(x != null)
            {
                var lowerCaseTitle = x.ToLower();
                var bookSearch = _bookService.SearchBooks(lowerCaseTitle);

                if(bookSearch.Count != 0)
                {
                    return View(bookSearch);
                }
                return View("NotFound");
            }
            return View();
        }

        public IActionResult BooksAlphabet()
        {
            var booksAlphaOrder = _bookService.BooksAlphabet();
            return View(booksAlphaOrder);
        }



    }
}

