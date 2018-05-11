using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.InputModels
{
    public class AddressInputModel
    {
        public string UserId { get; set; }

        [Required(ErrorMessage = "Street name is required")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "House number is required")]
        public int HouseNumber { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Zip code is required")]
        public int ZipCode { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
    }
}