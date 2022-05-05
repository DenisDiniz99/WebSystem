namespace WebSystem.Mvc.Core.ValuesObject
{
    public class Address
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }

        public Address() { }

        public Address(string street, string number, string neighborhood, string city, string state, string zipcode)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipcode;
        }
    }
}
