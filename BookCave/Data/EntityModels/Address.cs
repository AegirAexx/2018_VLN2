namespace BookCave.Data.EntityModels
{
    public class Address
    {
        public int addressId { get; set; }
        public int UserId { get; set; }
        public string streetName { get; set; }
        public string houseNumber { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int zipCode { get; set; }
        public bool isShippingAddress { get; set; }

    }
}