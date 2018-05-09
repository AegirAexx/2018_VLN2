using System.Collections.Generic;
using BookCave.Data.EntityModels;

namespace BookCave.Services
{
    public class ShoppingCart
    {
        // Data Repo connection?
        // Constructor?
        public int Id { get; set; } // UserId
        public Order CompleteOrder { get; set; } // Til að binda eina pöntun við hvert cart. Unique orderId.
        public List<OrderItem> CartOrderItemList { get; set; }
        
        public static ShoppingCart GetCart()
        {
            // ISession method?

            // Tengja cart við session / API / User klasi initiate method
            
            return new ShoppingCart();
        }

        public List<Book> GetCartList(/*odrer id*/)
        {
            // If userId == Id / orderId
            // Return Cart
            // Else if no match
            // new ShoppingCart(userId) || Exception?

            var cartBookList = new List<Book>(); // LINQ Query með "CartOrederItemList"
            
            return cartBookList; 
        }

        public void AddToCart(Book book, int amount)
        {
            // Logic check "amount"
            // Búa til OrderItem object útfrá Bók input (LINQ.SingleOrDefault)
            // If OrderItem.BookId == null && OrderItem. ( shopping cart inniheldur ekki bókina fyrir)
            // Skrifa OrderItem object í töflu
            // Else
            // OrderItem.amount++ && skrifa í grunninn 
                // (Kannski að gera Amount Fall til að skila "int" með LINQ.Sum())
                // Því að hver einasta bók sem fer í körfuna fær færslu í gagnagrunninn

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
