namespace BookCave.Data.EntityModels
{
    public class User
    {
       public int Id { get; set; }
       public string UserName { get; set; }
       public string FullName { get; set; }
       public string Password { get; set; }
       public string Email { get; set; }
       public string Gender { get; set; }
       public string Age { get; set; }
       public int FavoriteBook { get; set; }
       public int isActive { get; set; }
       public int JobTitle { get; set; }
       public int CreditCard { get; set; }
       public string Image { get; set; }
    }
}