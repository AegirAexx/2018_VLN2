using System;

namespace BookCave.Data.EntityModels
{
    public class Update
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FavoriteBook { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
    }
}