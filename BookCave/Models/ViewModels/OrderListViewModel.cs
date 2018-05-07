using System.Collections.Generic;
using BookCave.Data.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class OrderListViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderItemViewModel> OrderItems  = new List<OrderItemViewModel>();
    }
}