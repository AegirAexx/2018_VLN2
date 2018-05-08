using System.Collections.Generic;
using BookCave.Data.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class OrderService
    {
        private OrderRepo _orderRepo;

        public OrderService()
        {
            _orderRepo = new OrderRepo();
        }

       public List<OrderListViewModel> GetAllOrders()
       {
           var orders = _orderRepo.GetAllOrders();

           return orders;
       }

        /*  //á eftir að breyta þessu í order - Dagur
       public void AddOrder(User newUser)
       {
           _userRepo.AddUser(newUser);
       }*/
    }
}