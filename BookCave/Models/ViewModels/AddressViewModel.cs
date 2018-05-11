using System.ComponentModel.DataAnnotations;

namespace BookCave.Models.ViewModels
{
    public class AddressViewModel
    {
        [Required]
        public string StreetName { get; set; }
        [Required]
        public int HouseNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public string Name { get; set; }
    }
}