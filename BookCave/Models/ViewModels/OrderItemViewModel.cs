using System.Collections.Generic;
using BookCave.Data.EntityModels;

namespace BookCave.Models.ViewModels
{
    public class OrderItemViewModel
    {
        public int BillingAddress { get; set; }
        public int ShippingAddress { get; set; }
       // public BookListViewModel Book { get; set; }

    }
}