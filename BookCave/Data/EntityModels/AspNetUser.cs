namespace BookCave.Data.EntityModels
{
    public class AspNetUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FavoriteBook { get; set; }
        public string Image { get; set; }
    }
}