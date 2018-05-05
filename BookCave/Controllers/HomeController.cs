using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;

namespace BookCave.Controllers
{
    public class HomeController : Controller
    {
        private BookService _bookService;

        private UserService _userService;

        public HomeController()
        {
            _bookService = new BookService();

            _userService = new UserService();
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

        public IActionResult SeeUsers()
        {
            var users = _userService.GetAllUsers();
            return View(users);
        }

    }
}
