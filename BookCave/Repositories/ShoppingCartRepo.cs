using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Data.EntityModels;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class ShoppingCartRepo
    {
        private DataContext _db;

        public ShoppingCartRepo()
        {
            _db = new DataContext();
        }

        public List<CartBookViewModel> GetCartList(string userId)
        {
            var cartBooks = (from o in _db.OrderItems
                                where o.UserId == userId && o.Status == "Cart"
                                select new CartBookViewModel
                                {
                                    Id = o.BookId,
                                    Price = o.Price,
                                    Title = (from b in _db.Books
                                            where b.Id == o.BookId
                                            select b.Title).SingleOrDefault(),
                                    Author = (from b in _db.Books
                                            where b.Id == o.BookId
                                            select b.Author).SingleOrDefault()
                                }).ToList();
                
                return cartBooks;
        }

        public int GetCartId(string currentUser)
        {
            var cartId = (from o in _db.Orders
                        where o.UserId == currentUser && o.OrderStatus == "Cart"
                        select o.Id).SingleOrDefault();

            if(cartId != 0)
            {
                return cartId;
            }
            else
            {

                var newCart = new Order
                                    {
                                        UserId = currentUser,
                                        TotalPrice = 0,
                                        OrderStatus = "Cart"
                                    };
                _db.Orders.Add(newCart);
                _db.SaveChanges();
            }

            var newCartId = (from o in _db.Orders
                        where o.UserId == currentUser && o.OrderStatus == "Cart"
                        select o.Id).SingleOrDefault();

            return newCartId;
        }

        public void Add(int bookToAdd, string currentUser, int cartId)
        {
            var newCartItem = new OrderItem
                                    {
                                        BookId = bookToAdd,
                                        Price = 50,
                                        OrderId = cartId,
                                        Status = "Cart",
                                        UserId = currentUser
                                    };
            _db.OrderItems.Add(newCartItem);
            _db.SaveChanges();
        }

    }
}