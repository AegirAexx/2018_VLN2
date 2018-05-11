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
        private BookService _bookService;

        private OrderService _orderService;

        private ShoppingCartService _shoppingCartService;

         private AddressService _addressService;

        private readonly UserManager<ApplicationUser> _userManager;

        public ShoppingCartController(UserManager<ApplicationUser> userManager)
        {
            _bookService = new BookService();

            _orderService = new OrderService();

            _shoppingCartService = new ShoppingCartService();

            _addressService = new AddressService();

            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var currentUser = _userManager.GetUserId(HttpContext.User);

            var cartBookList = _shoppingCartService.GetCartList(currentUser);

            if(cartBookList.Count() < 1)
            {
                return View("Empty");
            }
            else
            {
                return View(cartBookList);
            }
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

        public IActionResult Address()
        {
            var currentUser = _userManager.GetUserId(HttpContext.User);
            
            var userAddresses = _addressService.GetAddresses(currentUser);
            return View(userAddresses);
        }

        public IActionResult CheckOut(int id)
        {
            var order = _shoppingCartService.CheckOut(id);
            
            return View(order);
        }

        public IActionResult Buy(int id)
        {
            var order = _shoppingCartService.Buy(id);
            
            return View(order);
        }

        [HttpPost]
        public IActionResult AddAddress(AddressInputModel address)
        {
            
            var currentUser = _userManager.GetUserId(HttpContext.User);

            _addressService.AddAddress(address, currentUser);

            return View("Address");
        }

    }
}

