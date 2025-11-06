using CompanyStructureService.Domain.Department;
using CompanyStructureService.Domain.Shared;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureService.Domain.Locations
{
    public record LocationName
    {
        private const int MIN_LENGTH = 3;
        private const int MAX_LENGTH = 120;

        public string Value { get; }

        private LocationName(string value)
        {
            Value = value;
        }

        public static Result<LocationName> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<LocationName>("Location name cannot be empty");

            name = name.Trim();

            if (!name.IsValidLength(MIN_LENGTH, MAX_LENGTH))
                return Result.Failure<LocationName>($"Location name must be > {MIN_LENGTH} and < {MAX_LENGTH} characters");

            return Result.Success(new LocationName(name));
        }
    }
}
