using System.Collections.Generic;
using System.Linq;
using BookCave.Data;
using BookCave.Models.ViewModels;
using BookCave.Models.InputModels;
using BookCave.Data.EntityModels;

namespace BookCave.Repositories
{
    public class AddressRepo
    {
        private DataContext _db;

        public AddressRepo()
        {
            _db = new DataContext();
        }

        public void AddAddress(Address address)
        {
            _db.Addresses.Add(address);
            _db.SaveChanges();
        }

        public List<AddressViewModel> GetAddresses(string currentUser)
        {
            var userAddresses = (from a in _db.Addresses
                                where a.UserId == currentUser
                                select new AddressViewModel
                                {
                                    StreetName = a.StreetName,
                                    HouseNumber = a.HouseNumber,
                                    City = a.City,
                                    Country = a.Country,
                                    ZipCode = a.ZipCode,
                                    Name = a.Name
                                }).ToList();

            return userAddresses;
        }
    }

}