using System.Collections.Generic;
using BookCave.Data.EntityModels;

namespace BookCave.Models.ViewModels ///Ný klasi fyrir Order history
///notenda. Setti inn eitthvað til að geta búið til útlitið
///má henda og þarf að búa til query fyrir order history -Arnar
{
    public class CustomerOrderHistoryViewModel
    {
        
        private List<OrderItemViewModel> orderItems = new List<OrderItemViewModel>();
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string UserName { get; set; }
        public int TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public List<OrderItemViewModel> OrderItems { get => orderItems; set => orderItems = value; }
    }
}