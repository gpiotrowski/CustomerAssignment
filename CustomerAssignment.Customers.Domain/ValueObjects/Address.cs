namespace CustomerAssignment.Customers.Domain.ValueObjects
{
    public struct Address
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string AppartmentNumber { get; set; }
        public string ZipCode { get; set; }
    }
}
