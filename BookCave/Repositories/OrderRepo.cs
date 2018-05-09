using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class OrderRepo
    {
        private DataContext _db;

        public OrderRepo()
        {
            _db = new DataContext();
        }

       public List<OrderListViewModel> GetAllOrders()
       {
           var orders = (from o in _db.Orders
                        select new OrderListViewModel
                        {
                           Id = o.Id,
                           CustomerId = o.CustomerId,
                           UserName = o.UserName,
                           TotalPrice = o.TotalPrice,
                           OrderStatus = o.OrderStatus,
                           OrderItems = (from oi in _db.OrderItems
                                        where oi.OrderId == o.Id
                                        select new OrderItemViewModel
                                        {
                                            BookId = oi.BookId,
                                            Price = oi.Price,
                                            Book = (from b in _db.Books
                                                    where b.Id == oi.BookId
                                                    select new BookListViewModel
                                                    {
                                                        Title = b.Title,
                                                        Id = b.Id
                                                    }).ToList()
                                        }).ToList()
                        }).ToList();
           return orders;
       }

       public List<CartBookViewModel> GetCartList(string userName)
       {
           var cartBooks = (from o in _db.OrderItems
                            where o.UserName == userName && o.Status == "Cart"
                            select new CartBookViewModel
                            {
                                Id = o.BookId,
                                Price = o.Price,
                                Title = (from b in _db.Books
                                        where b.Id == o.BookId
                                        select b.Title).SingleOrDefault()
                            }).ToList();
            
            return cartBooks;
       }

    }
}