using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookCave.Models;
using BookCave.Services;
using Microsoft.AspNetCore.Identity;

namespace BookCave.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private OrderService _orderService;

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction("index", "Home");
        }
        public CustomerController(UserManager<ApplicationUser> userManager)
        {
            _orderService = new OrderService();

            _userManager = userManager;
        }

        public IActionResult OrderHistory()
        {
            var currentUser = _userManager.GetUserId(HttpContext.User);

            var orders = _orderService.GetAllOrders(currentUser);
            return View(orders);
        }

        public IActionResult OrderDetails(int id)
        {
            
            var orderItems = _orderService.GetOrderDetails(id);
            
            return View(orderItems);
        }


    }
}