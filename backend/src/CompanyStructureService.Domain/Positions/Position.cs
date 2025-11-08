using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureService.Domain.Positions
{
    public class Position
    {
        //EFCore
        public Position() { }


        public PositionId Id { get; private set; }
        public PositionName Name { get; private set; }
        public PositionDescription? Description { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Position(PositionId id, PositionName name, PositionDescription? description)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public static Result<Position> Create(PositionId id, PositionName name, PositionDescription description)
        {
            return Result.Success(new Position(id, name, description));
        }
    }
}
