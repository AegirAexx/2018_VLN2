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
    public class WarehouseController : Controller
    {
        // private Service _Service; // Vantar Service

        public WarehouseController()
        {
            // _bookService = new BookService();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("index", "Home");
        }
    }
}