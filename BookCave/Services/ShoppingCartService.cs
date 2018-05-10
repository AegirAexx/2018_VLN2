using System.Collections.Generic;
using BookCave.Data.EntityModels;
using BookCave.Models;
using BookCave.Models.ViewModels;
using BookCave.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BookCave.Services
{
    public class ShoppingCartService
    {
        private OrderRepo _orderRepo;
        private BookRepo _bookRepo;
        private ShoppingCartRepo _shoppingCartRepo;

        public ShoppingCartService()
        {
            _bookRepo = new BookRepo();
            _orderRepo = new OrderRepo();
            _shoppingCartRepo = new ShoppingCartRepo();
        }

        public List<CartBookViewModel> GetCartList(string userId)
        {
            var cartBookList = _shoppingCartRepo.GetCartList(userId);
            
            return cartBookList; 
        }

        public void Add(int bookToAdd, string currentUser)
        {
            var cartId = GetCartId(currentUser);
            
            _shoppingCartRepo.Add(bookToAdd, currentUser, cartId);

        }

        public void Remove(int orderItem)
        {
            _shoppingCartRepo.Remove(orderItem);

        }


        public int GetCartTotal(int id)
        {
            // LINQ til að skoða öll verðin og leggja það saman.
            var total = 10000 + id;
            return total;
        }

        public int GetCartId(string currentUser)
        {
            var cartId = _shoppingCartRepo.GetCartId(currentUser);

            return cartId;
        }

        public PayOrderViewModel  CheckOut(int id)
        {
            var totalPrice = GetCartTotal(id); 
            
            var orderDetails = _shoppingCartRepo.CheckOut(id, totalPrice);
            
            return orderDetails;
        }

        public PayOrderViewModel Buy(int id)
        {
            var orderDetails = _shoppingCartRepo.Buy(id);
            
            return orderDetails;
        }
    }

}
