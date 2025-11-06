using System;
using CSharpFunctionalExtensions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CompanyStructureService.Domain.Shared;

namespace CompanyStructureService.Domain.Department
{
    public class DepartmentName
    {
        private const int MIN_LENGTH = 3;
        private const int MAX_LENGTH = 100;

        public string Value { get; }

        private DepartmentName(string value)
        {
            Value = value;
        }

        public static Result<DepartmentName> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return Result.Failure<DepartmentName>("Department name cannot be empty");
            
            name = name.Trim();

            if (!name.IsValidLength(MIN_LENGTH, MAX_LENGTH))
                return Result.Failure<DepartmentName>($"Department name must be > {MIN_LENGTH} and < {MAX_LENGTH} characters");

            return Result.Success(new DepartmentName(name));
        }
    }
}
