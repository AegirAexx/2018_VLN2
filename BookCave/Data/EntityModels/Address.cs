namespace BookCave.Data.EntityModels
{
    public class Address
    {
        public int Id { get; set; }
        public int addressId { get; set; }
        public int UserId { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public string Name { get; set; }

    }
}