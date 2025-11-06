using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureService.Domain.Locations
{
    public record LocationAddress
    {
        public string Country { get; }
        public string City { get; }
        public string Street { get; }
        public string PostalCode { get; }

        public LocationAddress(string country, string city, string street, string postalCode)
        {
            Country = country;
            City = city;
            Street = street;
            PostalCode = postalCode;
        }

        public static Result<LocationAddress> Create(string country, string city, string street, string postalCode)
        {
            if (string.IsNullOrWhiteSpace(country))
                return Result.Failure<LocationAddress>("Country cannot be empty");
            if (string.IsNullOrWhiteSpace(city))
                return Result.Failure<LocationAddress>("City cannot be empty");
            if (string.IsNullOrWhiteSpace(street))
                return Result.Failure<LocationAddress>("Street cannot be empty");
            if (string.IsNullOrWhiteSpace(postalCode))
                return Result.Failure<LocationAddress>("Postal code cannot be empty");

            return Result.Success(new LocationAddress(country, city, street, postalCode));
        }
    }
}
