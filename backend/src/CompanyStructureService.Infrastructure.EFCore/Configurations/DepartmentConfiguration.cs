using CompanyStructureService.Domain.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyStructureService.Infrastructure.EFCore.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        ConfigureTable(builder);
        ConfigureProperties(builder);
        ConfigureValueObjects(builder);
        ConfigureParentChild(builder);
        ConfigureNavigations(builder);
    }

    private static void ConfigureTable(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departments");
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
            .HasConversion(id => id.Value, value => DepartmentId.Create(value))
            .HasColumnName("id");
    }

    private static void ConfigureProperties(EntityTypeBuilder<Department> builder)
    {
        builder.Property(d => d.ParentId)
            .HasColumnName("parent_id");

        builder.Property(d => d.Depth)
            .HasColumnName("depth")
            .IsRequired();

        builder.Property(d => d.IsActive)
            .HasColumnName("is_active")
            .HasDefaultValue(true);

        builder.Property(d => d.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(d => d.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired();
    }

    private static void ConfigureValueObjects(EntityTypeBuilder<Department> builder)
    {
        builder.OwnsOne(d => d.Name, nb =>
        {
            nb.Property(v => v.Value)
              .IsRequired()
              .HasColumnName("name");
        });

        builder.OwnsOne(d => d.Identifier, ib =>
        {
            ib.Property(v => v.Value)
              .IsRequired()
              .HasColumnName("identifier");
        });

        builder.OwnsOne(d => d.Path, pb =>
        {
            pb.Property(v => v.Value)
              .IsRequired()
              .HasColumnName("path");
        });
    }

    private static void ConfigureParentChild(EntityTypeBuilder<Department> builder)
    {
        builder.Property(d => d.ParentId)
            .HasColumnName("parent_id")
            .HasConversion(
                id => id.Value,
                value => DepartmentId.Create(value))
            .IsRequired(false);

        builder.HasOne<Department>()
            .WithMany()
            .HasForeignKey(d => d.ParentId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    private static void ConfigureNavigations(EntityTypeBuilder<Department> builder)
    {
        builder.Navigation(d => d.PositionIds)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("_positionIds");

        builder.Navigation(d => d.LocationIds)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasField("_locationIds");
    }
}
