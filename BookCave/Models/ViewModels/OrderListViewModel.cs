namespace BookCave.Models.ViewModels
{
    public class OrderListViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int TotalPrice { get; set; }
        public string OrderStatus { get; set; }
    }
}