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
            var cartBooks = (from oi in _db.OrderItems
                                where oi.UserId == userId && oi.Status == "Cart"
                                select new CartBookViewModel
                                {
                                    Id = oi.Id,
                                    Price = oi.Price,
                                    Title = (from b in _db.Books
                                            where b.Id == oi.BookId
                                            select b.Title).SingleOrDefault(),
                                    Author = (from b in _db.Books
                                            where b.Id == oi.BookId
                                            select b.Author).SingleOrDefault(),
                                    OrderId = oi.OrderId,
                                    ISBN13 = (from b in _db.Books
                                            where b.Id == oi.BookId
                                            select b.ISBN13).SingleOrDefault()
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
                                        OrderStatus = "Cart",
                                        BillingAddressId = 0,
                                        ShippingAddressId = 0
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

        public void Remove(int orderItem)
        {
            var itemToRemove = (from oi in _db.OrderItems
                                where oi.Id == orderItem
                                select oi).SingleOrDefault();
            
            if(itemToRemove != null)
            {
                _db.OrderItems.Remove(itemToRemove);
                _db.SaveChanges();
            }
        }
        public PayOrderViewModel CheckOut(int id, int price)
        {
            
            var orderDetails = (from o in _db.Orders
                                where o.Id == id
                                select new PayOrderViewModel
                                {
                                    Id = o.Id,
                                    TotalPrice = price
                                }).SingleOrDefault();
            
            return orderDetails;
        }

        public PayOrderViewModel Buy(int id)
        {
            var orderItemsToBuy = (from oi in _db.OrderItems
                                    where oi.OrderId == id
                                    select oi).ToList();
            
            foreach(var item in orderItemsToBuy)
            {
                item.Status = "Order";
            }
            _db.SaveChanges();
            
            var orderDetails = (from o in _db.Orders
                                where o.Id == id
                                select new PayOrderViewModel
                                {
                                    Id = o.Id,
                                    TotalPrice = o.TotalPrice
                                }).SingleOrDefault();
            
            return orderDetails;
        }
    }
}