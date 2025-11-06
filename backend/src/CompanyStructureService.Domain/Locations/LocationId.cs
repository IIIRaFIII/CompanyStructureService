using CompanyStructureService.Domain.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureService.Domain.Locations
{
    public record LocationId
    {
        public Guid Value { get; }

        private LocationId(Guid value) => Value = value;
        public static LocationId Create(Guid id) => new(id);
        public static LocationId NewDepartmentId() => new(Guid.NewGuid());
        public static LocationId EmptyDepartmentId() => new(Guid.Empty);
    }
}
