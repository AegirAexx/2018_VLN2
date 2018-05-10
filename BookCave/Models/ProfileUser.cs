using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BookCave.Models
{
    public class ProfileUser
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string FavoriteBook { get; set; }
    }
}