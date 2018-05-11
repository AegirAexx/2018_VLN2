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

        public IActionResult Index()
        {
            return View();
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
            
            if(orderItems.Count() == 0)
            {
                return View("bfdjkasfbdsbkj");
            }
            return View(orderItems);
        }

    }
}