using System.Collections.Generic;
using BookCave.Data.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class OrderListViewModel
    {
        private List<OrderItemViewModel> orderItems = new List<OrderItemViewModel>(); 
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CustomerName { get; set; }
        public int TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderItemViewModel> OrderItems { get => orderItems; set => orderItems = value; }
    }
}