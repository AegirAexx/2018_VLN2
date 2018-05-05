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
    public class BookController : Controller
    {
        // private Service _Service; // Vantar Service

        public BookController()
        {
            // _bookService = new BookService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details(/*int id*/)
        {
            // @TODO
            // Here we need to add the logic that can pass each book from database to the view
            return View();
        }
    }
}