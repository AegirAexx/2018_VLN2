namespace BookCave.Models.ViewModels
{
    public class CartBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Author { get; set; }
        public int OrderId { get; set; }

        public string ISBN13 { get; set; }
    }
}