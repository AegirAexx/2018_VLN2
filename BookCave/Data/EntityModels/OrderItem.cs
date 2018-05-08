namespace BookCave.Data.EntityModels
{
    public class OrderItem
    {
       public int Id { get; set; }
       public int BookId { get; set; }
       public int Price { get; set; }
       public int OrderId { get; set; }
    }
}