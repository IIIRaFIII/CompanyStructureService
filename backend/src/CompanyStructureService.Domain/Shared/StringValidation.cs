using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompanyStructureService.Domain.Shared
{
    public static class StringValidation
    {
        public static bool IsLatinOnly(this string value) =>
        !string.IsNullOrEmpty(value) && Regex.IsMatch(value, @"^[a-zA-Z0-9._-]+$");

        public static bool IsValidLength(this string value, int min, int max) =>
            !string.IsNullOrEmpty(value) && value.Length >= min && value.Length <= max;
    }
}
