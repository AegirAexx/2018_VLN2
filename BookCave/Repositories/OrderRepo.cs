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

       public List<OrderListViewModel> GetAllOrders(string currentUser)
       {
           var orders = (from o in _db.Orders
                        where o.UserId == currentUser && o.OrderStatus != "Cart"
                        select new OrderListViewModel
                        {
                           Id = o.Id,
                           UserId = o.UserId,
                           TotalPrice = o.TotalPrice,
                           OrderStatus = o.OrderStatus,
                           UserName = (from u in _db.AspNetUsers
                                        where u.Id == currentUser
                                        select u.Email).SingleOrDefault()
                           /*OrderItems = (from oi in _db.OrderItems
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
                                        }).ToList()*/
                        }).ToList();
           return orders;
       }

        public List<OrderItemViewModel> GetOrderDetails(int orderId)
        {
            var billingAddressId = (from o in _db.Orders
                                    where o.Id == orderId
                                    select o.BillingAddressId).SingleOrDefault();
            
            var shippingAddressId = (from o in _db.Orders
                                    where o.Id == orderId
                                    select o.ShippingAddressId).SingleOrDefault();
            
            
            var orderItems = (from oi in _db.OrderItems
                            where oi.OrderId == orderId
                            select new OrderItemViewModel
                            {
                                BillingAddress = (from a in _db.Addresses
                                                where a.Id == billingAddressId
                                                select new AddressViewModel
                                                {
                                                    StreetName = a.StreetName,
                                                    HouseNumber = a.HouseNumber,
                                                    City = a.City,
                                                    Country = a.Country,
                                                    ZipCode = a.ZipCode,
                                                }).SingleOrDefault(),
                                ShippingAddress = (from a in _db.Addresses
                                                where a.Id == shippingAddressId
                                                select new AddressViewModel
                                                {
                                                    StreetName = a.StreetName,
                                                    HouseNumber = a.HouseNumber,
                                                    City = a.City,
                                                    Country = a.Country,
                                                    ZipCode = a.ZipCode,
                                                }).SingleOrDefault(),
                                Book = (from b in _db.Books
                                        where oi.BookId == b.Id
                                        select new BookListViewModel
                                        {
                                            Id = b.Id,
                                            Title = b.Title,
                                            Rating = b.Rating,
                                            Genre = b.Genre,
                                            ISBN13 = b.ISBN13,
                                            Author = b.Author
                                        }).SingleOrDefault()
                            }).ToList();

            return orderItems;
        }

    }
}