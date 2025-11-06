using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureService.Domain.Department
{

    public record DepartmentId
    {
        public Guid Value { get; }

        private DepartmentId(Guid value) => Value = value;
        public static DepartmentId Create(Guid id) => new(id);
        public static DepartmentId NewDepartmentId() => new(Guid.NewGuid());
        public static DepartmentId EmptyDepartmentId() => new(Guid.Empty);
    }
}
