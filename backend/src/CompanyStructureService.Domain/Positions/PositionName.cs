using CompanyStructureService.Domain.Shared;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureService.Domain.Positions
{
    public class PositionName
    {
        private const int MIN_LENGTH = 3;
        private const int MAX_LENGTH = 100;

        public string Value { get; }

        private PositionName(string value)
        {
            Value = value;
        }

        public static Result<PositionName> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<PositionName>("Position name cannot be empty");

            name = name.Trim();

            if (!name.IsValidLength(MIN_LENGTH, MAX_LENGTH))
                return Result.Failure<PositionName>($"Position name must be > {MIN_LENGTH} and < {MAX_LENGTH} characters");

            return Result.Success<PositionName>(new PositionName(name));
        }
    }
}