using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class FrontPageViewModel
    {
        private List<BookDetailsViewModel> sciFi = new List<BookDetailsViewModel>();

        private List<BookDetailsViewModel> children = new List<BookDetailsViewModel>();
        private List<BookDetailsViewModel> contemporary = new List<BookDetailsViewModel>();
        private List<BookDetailsViewModel> fantasy = new List<BookDetailsViewModel>();
        private List<BookDetailsViewModel> youngAdult = new List<BookDetailsViewModel>();
        public List<BookDetailsViewModel> SciFi { get => sciFi; set => sciFi = value; }
        public List<BookDetailsViewModel> Children { get => children; set => children = value; }
        public List<BookDetailsViewModel> Contemporary { get => contemporary; set => contemporary = value; }
        public List<BookDetailsViewModel> Fantasy { get => fantasy; set => fantasy = value; }
        public List<BookDetailsViewModel> YoungAdult { get => youngAdult; set => youngAdult = value; }
    }
}