using System.Collections.Generic;
namespace BookCave.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public string UserName { get; set; }

        public List<CartBookViewModel> ShoppingCartList { get; set; }
        
        public int ShoppingCartTotal { get; set; }
    }
}
