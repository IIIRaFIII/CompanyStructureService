using CompanyStructureService.Domain.Department;
using CompanyStructureService.Domain.Positions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureService.Infrastructure.EFCore.Configurations
{
    public class DepartmentPositionConfiguration : IEntityTypeConfiguration<DepartmentPosition>
    {
        public void Configure(EntityTypeBuilder<DepartmentPosition> builder)
        {
            builder.ToTable("department_positions");

            builder.HasKey(dp => new { dp.DepartmentId, dp.PositionId })
                .HasName("pk_department_positions");

            builder.Property(dp => dp.DepartmentId)
                .HasConversion(id => id.Value, value => DepartmentId.Create(value))
                .HasColumnName("department_id")
                .IsRequired();

            builder.Property(dp => dp.PositionId)
                .HasConversion(id => id.Value, value => PositionId.Create(value))
                .HasColumnName("position_id")
                .IsRequired();

            builder.HasOne<Position>()
                .WithMany()
                .HasForeignKey(dp => dp.PositionId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_department_positions_position");
        }
    }
}