using Framework.Domain.Abstractions;
using System;
using System.Collections.Generic;

namespace ValueObjectAsField.Domain.Models
{
    public class Address : ValueObject<Address>
    {
        public static Address CreateWith(string city, string street, int unit, string zipCode)=> new Address(city, street, unit, zipCode);
        protected Address(string city, string street, int unit, string zipCode)
        {
            if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(street) || string.IsNullOrEmpty(zipCode))
                throw new ArgumentException("Address cannot accept null parameters");
            if (unit is default(int))
                throw new ArgumentException("Addres must has valid unit");

            City = city;
            Street = street;
            Unit = unit;
            ZipCode = zipCode;
        }

        public string City { get; private set; }
        public string Street { get; private set; }
        public int Unit { get; private set; }
        public string ZipCode { get; private set; }

        public Address ChangeWith(string city, string street, int unit, string zipCode)=> new Address(city, street, unit, zipCode);

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return City;
            yield return Street;
            yield return Unit;
            yield return ZipCode;
        }
    }
}
