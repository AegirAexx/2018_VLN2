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

        public void AddAddress(AddressInputModel address, string currentUser)
        {
            var addressToAdd = new Address
                                    {
                                        UserId = currentUser,
                                        StreetName = address.StreetName,
                                        HouseNumber = address.HouseNumber,
                                        City = address.City,
                                        Country = address.Country,
                                        ZipCode = address.ZipCode,
                                        Name = address.Name
                                    };
            
            _addressRepo.AddAddress(addressToAdd);
        }

        public List<AddressViewModel> GetAddresses(string currentUser)
        {
            var userAddresses = _addressRepo.GetAddresses(currentUser);

            return userAddresses;
        }


    }
}