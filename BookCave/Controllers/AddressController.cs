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
    public class AddressController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private AddressService _addressService;

        public IActionResult Index()
        {
            return View();
        }
        public AddressController(UserManager<ApplicationUser> userManager)
        {
            _addressService = new AddressService();

            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult AddAddress()
        {
            var currentUser = _userManager.GetUserId(HttpContext.User);


            return View();
        }

    }
}