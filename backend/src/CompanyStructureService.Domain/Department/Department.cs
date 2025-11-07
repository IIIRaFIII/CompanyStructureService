using CompanyStructureService.Domain.Locations;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureService.Domain.Department
{
    public class Department
    {
        //EFCore
        private Department() { }


        private readonly List<DepartmentPosition> _positionIds = [];
        private readonly List<DepartmentLocation> _locationIds;

        public DepartmentId Id { get; private set; }
        public DepartmentName Name { get; private set; }
        public DepartmentIdentifier Identifier { get; private set; }
        public DepartmentId? ParentId { get; private set; }
        public DepartmentPath Path { get; }
        public short Depth { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public IReadOnlyList<DepartmentLocation> LocationIds => _locationIds;
        public IReadOnlyList<DepartmentPosition> PositionIds => _positionIds;

        private Department(DepartmentId id, DepartmentName name, DepartmentIdentifier identifier, DepartmentId? parentId, DepartmentPath path, short depth, IEnumerable<DepartmentLocation> locations)
        {
            Id = id;
            Name = name;
            Identifier = identifier;
            ParentId = parentId;
            Path = path;
            Depth = depth;
            IsActive = true;
            _locationIds = locations.ToList();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Result<Department> Create(
            DepartmentId id,
            DepartmentName name,
            DepartmentIdentifier identifier,
            List<DepartmentLocation> locations,
            Department? parent = null)
        {
            if (locations == null || locations.Count == 0)
                return Result.Failure<Department>("Department must have at least one location");

            var path = DepartmentPath.BuildFrom(identifier, parent?.Path);
            short depth = CalculateDepth(parent);

            return Result.Success(new Department(
                id,
                name,
                identifier,
                parent?.Id,
                path,
                depth,
                locations));
        }

        private static short CalculateDepth(Department? parent)
        {
            return (parent == null ? (short)0 : (short)(parent.Depth + 1));
        }
    }
}
