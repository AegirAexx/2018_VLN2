using System;

namespace BookCave.Data.EntityModels
{
    public class Order
    {
       public int Id { get; set; }
       public string UserId { get; set; }
       public int TotalPrice { get; set; }
       public string OrderStatus { get; set; }
       public int BillingAddressId { get; set; }
       public int ShippingAddressId { get; set; } 
    }
}