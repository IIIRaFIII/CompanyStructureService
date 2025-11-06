using CompanyStructureService.Domain.Shared;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CompanyStructureService.Domain.Department
{
    public class DepartmentIdentifier
    {
        private const int MIN_LENGTH = 3;
        private const int MAX_LENGTH = 150;

        public string Value { get; }

        private DepartmentIdentifier(string value)
        {
            Value = value;
        }

        public Result<DepartmentIdentifier> Create(string identifier)
        {
            if(string.IsNullOrWhiteSpace(identifier))
            {
                return Result.Failure<DepartmentIdentifier>("Department identifier cannot be empty");
            }
            identifier = identifier.Trim();

            if (!identifier.IsValidLength(MIN_LENGTH, MAX_LENGTH))
                return Result.Failure<DepartmentIdentifier>($"Department identifier must be > {MIN_LENGTH} and < {MAX_LENGTH} characters");


            if (!identifier.IsLatinOnly())
                return Result.Failure<DepartmentIdentifier>("Department identifier must contains only latin letters, digits, ._ - symbols");

            return Result.Success(new DepartmentIdentifier(identifier));
        }
    }
}
