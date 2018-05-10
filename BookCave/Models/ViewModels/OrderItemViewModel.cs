using System.Collections.Generic;

namespace BookCave.Models.ViewModels
{
    public class OrderItemViewModel
    {
        private List<BookListViewModel> book = new List<BookListViewModel>();
        public int BookId { get; set; }

        public int TotalPrice { get; set; }

        public List<BookListViewModel> Book { get => book; set => book = value; }
    }
}