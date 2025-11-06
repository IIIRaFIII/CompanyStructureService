using CompanyStructureService.Domain.Locations;
using CompanyStructureService.Domain.Positions;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureService.Domain.Department
{
    public class DepartmentPosition
    {
        public DepartmentId DepartmentId { get; }
        public PositionId PositionId { get; }
        private DepartmentPosition(DepartmentId departmentId, PositionId positionId)
        {
            DepartmentId = departmentId;
            PositionId = positionId;
        }

        public static Result<DepartmentPosition> Create(DepartmentId departmentId, PositionId positionId)
        {
            return Result.Success(new DepartmentPosition(departmentId, positionId));
        }
    }
}
