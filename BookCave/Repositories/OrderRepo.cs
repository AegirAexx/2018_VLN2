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
                           UserId = o.UserId,
                           TotalPrice = o.TotalPrice,
                           OrderStatus = o.OrderStatus,
                           CustomerName = (from user in _db.AspNetUsers
                                        where user.Id == o.UserId
                                        select user.LastName).SingleOrDefault(),
                           OrderItems = (from oi in _db.OrderItems
                                        where oi.OrderId == o.Id
                                        select new OrderItemViewModel
                                        {
                                            BookId = oi.BookId,
                                            TotalPrice = oi.Price,
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

    }
}