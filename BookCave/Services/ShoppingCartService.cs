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

        public void RemoveFromCart(Book book)
        {
            // Finna bókina
            // athuga ef það eru fleiri en eitt eintak af henni
            // If > 1
            // amount-- && Gera eitthvað við gagnagrunninn?
            // Else
            // Remove OrderItem form OrderItem List.
        }


        public decimal GetShoppingCartTotal()
        {
            // LINQ til að skoða öll verðin og leggja það saman.
            var total = new decimal();
            return total;
        }

        public int GetCartId(string currentUser)
        {
            var cartId = _shoppingCartRepo.GetCartId(currentUser);

            return cartId;
        }


    }

}
