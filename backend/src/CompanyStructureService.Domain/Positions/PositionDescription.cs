using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureService.Domain.Positions
{
    public class PositionDescription
    {
        private const int MAX_LENGTH = 1000;

        public string Value { get; }

        private PositionDescription(string value)
        {
            Value = value;
        }

        public static Result<PositionDescription> Create(string? description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return Result.Failure<PositionDescription>("Position description cannot be empty");

            description = description.Trim();

            if (description.Length > MAX_LENGTH)
                return Result.Failure<PositionDescription>($"Position description cannot be > {MAX_LENGTH} characters");

            return Result.Success<PositionDescription>(new PositionDescription(description));
        }
    }
}