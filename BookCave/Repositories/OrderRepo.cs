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
                           TotalPrice = o.TotalPrice,
                           OrderStatus = o.OrderStatus 
                        }).ToList();
           return orders;
       }

    }
}