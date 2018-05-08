namespace BookCave.Data.EntityModels
{
    public class Book
    {
       public int Id { get; set; }
       public string Title { get; set; }
       public int YearPublished { get; set; }

       public float Rating { get; set; }
    }
}
