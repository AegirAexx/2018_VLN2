namespace BookCave.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        // public ShoppingCart ShoppingCart { get; set; }
        
        // Er þetta ekki lin-kjúaður listi af OrderItems join við Books?
        // public Book<List> ShoppingCartList { get; set; }
        public decimal ShoppingCartTotal { get; set; }    
    }
}
