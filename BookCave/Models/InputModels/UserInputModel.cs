using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class UserInputModel
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Age { get; set; }
        [Required]
        public int FavoriteBook { get; set; }

    }
}