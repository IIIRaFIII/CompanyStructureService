using CompanyStructureService.Domain.Locations;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureService.Domain.Department
{
    public class DepartmentLocation
    {
        public DepartmentId DepartmentId { get; }
        public LocationId LocationId { get; }

        private DepartmentLocation(DepartmentId departmentId, LocationId locationId)
        {
            DepartmentId = departmentId;
            LocationId = locationId;
        }

        public static Result<DepartmentLocation> Create(DepartmentId departmentId, LocationId locationId)
        {
            return Result.Success(new DepartmentLocation(departmentId, locationId));
        }
    }
}
