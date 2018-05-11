using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using Microsoft.AspNetCore.Identity;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;

namespace BookCave.Controllers
{
    public class BookController : Controller
    {
        private BookService _bookService;

        private readonly UserManager<ApplicationUser> _userManager;

        public BookController(UserManager<ApplicationUser> userManager)
        {
            _bookService = new BookService();

            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var bookDetails = _bookService.BookDetails(id);

            return View(bookDetails);
        }

        [HttpPost]
        public IActionResult AddComment(CommentInputModel inputComment)
        {
            var currentUser = _userManager.GetUserId(HttpContext.User);

            _bookService.AddComment(inputComment, currentUser);

            int x = inputComment.BookId;

            return RedirectToAction("Details", "Book", new{id = x});
        }

        [HttpPost]
        public IActionResult AddRating(int bookId, int rating)
        {
            //Fall sem tekur við bookId og rating tölu frá notanda, sendir það svo áfram á service
            _bookService.AddRating(bookId, rating);

            return View();
        }

    }
}