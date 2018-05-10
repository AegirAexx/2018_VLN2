using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
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
                                            select b.Title).SingleOrDefault()
                                }).ToList();
                
                return cartBooks;
        }

    }
}