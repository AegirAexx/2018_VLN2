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

       public List<OrderListViewModel> GetAllOrders(string currentUser)
       {
           var orders = _orderRepo.GetAllOrders(currentUser);

           return orders;
       }

        public List<OrderItemViewModel> GetOrderDetails(int id)
        {
            var orderItems = _orderRepo.GetOrderDetails(id);
            
            return orderItems;
        }
    }
}