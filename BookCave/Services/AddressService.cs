using System.Collections.Generic;
using BookCave.Data.EntityModels;
using BookCave.Models.InputModels;
using BookCave.Models.ViewModels;
using BookCave.Repositories;

namespace BookCave.Services
{
    public class AddressService
    {
        private AddressRepo _addressRepo;

        public AddressService()
        {
            _addressRepo = new AddressRepo();
        }

        public void AddAddress()
        {
            //Byggja nytt address inputModel til að skrifa i grunninn
            

        }

    }
}