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
    public class ShoppingCartController : Controller
    {
        // Þarf controller ekki Data Repo?
        private BookService _bookService; // Read only?

        private OrderService _orderService; // Read only?

        private ShoppingCartService _shoppingCart;

        public ShoppingCartController()
        {
            _bookService = new BookService();

            _orderService = new OrderService();

            _shoppingCart = new ShoppingCartService();
        }

        [HttpGet]
        public IActionResult Index(string userName)
        {
            // @TODO Return heildar view fyrir fullscreen


            // var items = _shoppingCart.GetShoppingCartItems();
            // _shoppingCart.ShoppingCartItems = items;

            // var shoppingCartViewModel = new ShoppingCartViewModel
            // {
            //     ShoppingCart = _shoppingCart,
            //     ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            // };
            var cartBookList = _shoppingCart.GetCartList(userName);

            return View(cartBookList);
        }

        [HttpPost]
        public IActionResult AddToShoppingCart(/*int|inputmodel ???Id*/)
        {
            // Created an OrderItem? from JSON

            // Write to Memory(Push to Book<List>) 

            return Ok(/*NewShoppingCartViewModelItem*/);
            // It will be AJAX back into DOM to reflect change 
            // in the cart inventory.
        }

        // [HttpPost] || Delete?
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
        // Controller til að staðfesta pöntun og klára pöntun
        // Account tengingar?

    }
}

