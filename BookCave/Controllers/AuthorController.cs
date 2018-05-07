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
    public class AuthorController : Controller
    {
        // private Service _Service; // Vantar Service

        public AuthorController()
        {
            // _bookService = new BookService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}