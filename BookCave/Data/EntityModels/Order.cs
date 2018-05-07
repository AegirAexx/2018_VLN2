using System;

namespace BookCave.Data.EntityModels
{
    public class Order
    {
       public int Id { get; set; }
       public int CustomerId { get; set; }
       public int TotalPrice { get; set; }
       public string OrderStatus { get; set; }
    }
}