using CompanyStructureService.Domain.Locations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureService.Domain.Positions
{
    public class PositionId
    {
        public Guid Value { get; }

        private PositionId(Guid value) => Value = value;
        public static PositionId Create(Guid id) => new(id);
        public static PositionId NewDepartmentId() => new(Guid.NewGuid());
        public static PositionId EmptyDepartmentId() => new(Guid.Empty);
    }
}