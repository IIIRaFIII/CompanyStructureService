using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureService.Domain.Locations
{
    public class LocationTimezone
    {
        public string TimeZoneIANA => TimeZoneInfo.Id;
        public TimeZoneInfo TimeZoneInfo { get; }
        private LocationTimezone(TimeZoneInfo timezone)
        {
            TimeZoneInfo = timezone;
        }

        public static Result<LocationTimezone> Create(string timeZone)
        {
            if (string.IsNullOrWhiteSpace(timeZone))
                return Result.Failure<LocationTimezone>("Time zone is null");

            if (!TimeZoneInfo.TryFindSystemTimeZoneById(timeZone, out TimeZoneInfo? timeZoneInfo))
                return Result.Failure<LocationTimezone>("Invalid IANA timezone code");

            return new LocationTimezone(timeZoneInfo);
        }
    }
}