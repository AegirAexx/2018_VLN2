using System.Collections.Generic;
using BookCave.Data.EntityModels;

namespace BookCave.Models.ViewModels
{
  public class ShoppingCart
  {
    public string ShoppingCartId { get; set; }
    public List<OrderItem> OrderItem { get; set; }
    
  }
}