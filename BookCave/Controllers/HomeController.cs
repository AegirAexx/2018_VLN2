<<<<<<< HEAD
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

        public IActionResult GetOrders()
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

=======
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
>>>>>>> 3085b3ae3b5f404c29be07a92bfd8424de704df3
