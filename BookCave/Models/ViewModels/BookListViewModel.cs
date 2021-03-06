namespace BookCave.Models.ViewModels
{
    public class BookListViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Genre { get; set; }
        public string ISBN13 { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
    }
}
