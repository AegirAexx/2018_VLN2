namespace BookCave.Models.ViewModels
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }
        public int GoodReadsId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public int PageCount { get; set; }
        public int YearPublished { get; set; }
        public int OriginalPublicationYear { get; set; }
        public float Rating { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }
    }
}