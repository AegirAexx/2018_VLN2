using System.Collections.Generic;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class UserService
    {
        private UserRepo _userRepo;

        public UserService()
        {
            _userRepo = new UserRepo();
        }

       public List<UserListViewModel> GetAllUsers()
       {
           var users = _userRepo.GetAllUsers();

           return users;
       }
    }
}