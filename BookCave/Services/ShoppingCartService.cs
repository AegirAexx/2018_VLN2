using System.Collections.Generic;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class ShoppingCartService
    {
        private OrderRepo _orderRepo;
        private BookRepo _bookRepo;

        public ShoppingCartService()
        {
            _bookRepo = new BookRepo();
            _orderRepo = new OrderRepo();
        }
        public static ShoppingCartService GetCart()
        {
            // ISession method?

            // Tengja cart við session / API / User klasi initiate method
            
            return new ShoppingCartService();
        }

        public List<CartBookViewModel> GetCartList(string userName)
        {
            
            var cartBookList = _orderRepo.GetCartList(userName);
            
            return cartBookList; 
        }

        public void AddToCart(int bookId, string userName)
        {
            
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

        public void ClearCart()
        {
            // null stillir allt? Delete/Free method?
        }

        public decimal GetShoppingCartTotal()
        {
            // LINQ til að skoða öll verðin og leggja það saman.
            var total = new decimal();
            return total;
        }

        

    }

}
