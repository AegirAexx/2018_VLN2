<<<<<<< HEAD
﻿using System;
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

        private AuthorService _authorService;

        public HomeController()
        {
            _bookService = new BookService();

            _userService = new UserService();

            _authorService = new AuthorService();
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

        public IActionResult SeeAuthors()
        {
            var authors = _authorService.GetAllAuthors();
            return View(authors);
        }

    }
}
=======
﻿using System;
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
        private BookService _bookService;

        private OrderService _orderService;

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

        public IActionResult Getorders()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }

        /*   //Ég á eftir að breyta þessu í order - Dagur
        [HttpPost]
        public IActionResult AddUser(UserInputModel inputUser)
        {
            if(ModelState.IsValid)
            {
                var newUser = new User
                {
                    UserName = inputUser.UserName,
                    FullName = inputUser.FullName,
                    Email = inputUser.Email,
                    Gender = inputUser.Gender,
                    Age = inputUser.Age,
                    FavoriteBook = inputUser.FavoriteBook,
                    IsActive = 1,
                    JobTitle = "User",
                    Image = ""
                };

                _userService.AddUser(newUser);
                return RedirectToAction("Index");
            }
            return View();
        }*/

    }
}
>>>>>>> dagur
