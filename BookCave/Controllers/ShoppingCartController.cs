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
using Microsoft.AspNetCore.Identity;

namespace BookCave.Controllers
{
    public class ShoppingCartController : Controller
    {
        // Þarf controller ekki Data Repo?
        private BookService _bookService; // Read only?

        private OrderService _orderService; // Read only?

        private ShoppingCartService _shoppingCartService;

        private readonly UserManager<ApplicationUser> _userManager;

        public ShoppingCartController(UserManager<ApplicationUser> userManager)
        {
            _bookService = new BookService();

            _orderService = new OrderService();

            _shoppingCartService = new ShoppingCartService();

            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var currentUser = _userManager.GetUserId(HttpContext.User);

            var cartBookList = _shoppingCartService.GetCartList(currentUser);

            return View(cartBookList);
        }

        public IActionResult Add(int id)
        {
            var currentUser = _userManager.GetUserId(HttpContext.User);
            
            _shoppingCartService.Add(id, currentUser);

            return View();
        }

        public IActionResult Remove(int id)
        {
            _shoppingCartService.Remove(id);

            return View();
        }

        public IActionResult RemoveFromShoppingCart(/*int|inputmodel ???Id*/)
        {
            // Created an OrderItem? from JSON

            // Remove from Book<List> 

            return Ok(/*NewShoppingCartViewModelItem*/);
            // It will be AJAX back into DOM to reflect change 
            // in the cart inventory.
        }
        public IActionResult CheckOut()
        {
            return View();
        }

    }
}

