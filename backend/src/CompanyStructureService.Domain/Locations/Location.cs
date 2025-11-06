using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureService.Domain.Locations
{
    public class Location
    {
        public LocationId Id { get; private set; }
        public LocationName Name { get; private set; }
        public LocationAddress Address { get; private set; }
        public LocationTimezone Timezone { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Location(LocationId id, LocationName name, LocationAddress address, LocationTimezone timezone)
        {
            Id = id;
            Name = name;
            Address = address;
            Timezone = timezone;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Result<Location> Create(LocationId id, LocationName name, LocationAddress address, LocationTimezone timezone)
        {
            return Result.Success(new Location(id, name, address, timezone));
        }
    }
}
