namespace BookCave.Data.EntityModels
{
  public class OrderItem
  {
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int Price { get; set; }
    public string OrderId { get; set; }
  }
}