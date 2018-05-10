using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCave.Models.ViewModels
{
    public class EditProfileViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "FavoriteBook")]
        public string FavoriteBook { get; set; }
        [Display(Name = "Image")]
        public string Image { get; set; }

        public string StatusMessage { get; set; }
    }
}