using CompanyStructureService.Domain.Department;
using CompanyStructureService.Domain.Locations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyStructureService.Infrastructure.EFCore.Configurations
{
    public class DepartmentLocationConfiguration : IEntityTypeConfiguration<DepartmentLocation>
    {
        public void Configure(EntityTypeBuilder<DepartmentLocation> builder)
        {
            builder.ToTable("department_locations");

            builder.HasKey(dl => new { dl.DepartmentId, dl.LocationId })
                .HasName("pk_department_locations");

            builder.Property(dl => dl.DepartmentId)
                .HasConversion(id => id.Value, value => DepartmentId.Create(value))
                .HasColumnName("department_id")
                .IsRequired();

            builder.Property(dl => dl.LocationId)
                .HasConversion(id => id.Value, value => LocationId.Create(value))
                .HasColumnName("location_id")
                .IsRequired();

            builder.HasOne<Location>()
                .WithMany()
                .HasForeignKey(dl => dl.LocationId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_department_locations_location");
        }
    }
}