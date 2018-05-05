using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.ViewModels;

namespace BookCave.Repositories
{
    public class UserRepo
    {
        private DataContext _db;

        public UserRepo()
        {
            _db = new DataContext();
        }

       public List<UserListViewModel> GetAllUsers()
       {
           var users = (from u in _db.Users
                        select new UserListViewModel
                        {
                           UserId = u.UserId,
                           UserName = u.UserName,
                           FavoriteBook = u.FavoriteBook,
                           Image = u.Image
                        }).ToList();
           return users;
       }

    }
}