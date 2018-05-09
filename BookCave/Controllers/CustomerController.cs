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
    public class CustomerController : Controller
    {
        // private Service _Service; // Vantar Service


        ///Veit ekki hvort að þetta sé réttur staður en set OrderList hingað
        private OrderService _orderService;

        public CustomerController()
        {
            _orderService = new OrderService();
        }

        public IActionResult OrderHistory()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }

        public IActionResult OrderDetails()
        {
            var orders = _orderService.GetAllOrders();
            return View(orders);
        }

        // public CustomerController()
        // {
        //     _bookService = new BookService();
        // }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}