using System;

namespace BookCave.Data.EntityModels
{
    public class User
    {
       public int Id { get; set; }
       public string UserName { get; set; }
       public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
       public string Email { get; set; }
       public string Gender { get; set; }
       public string Age { get; set; }
       public int FavoriteBook { get; set; }
       public int IsActive { get; set; }
       public string JobTitle { get; set; }
       public string Image { get; set; }
    }
}