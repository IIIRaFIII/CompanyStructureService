using CompanyStructureService.Domain.Positions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CompanyStructureService.Infrastructure.EFCore.Configurations
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            ConfigureTable(builder);
            ConfigureProperties(builder);
            ConfigureValueObjects(builder);
        }

        private static void ConfigureTable(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("positions");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasConversion(id => id.Value, value => PositionId.Create(value))
                .HasColumnName("id");
        }

        private static void ConfigureProperties(EntityTypeBuilder<Position> builder)
        {
            builder.Property(p => p.IsActive)
                .HasColumnName("is_active")
                .HasDefaultValue(true);

            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(p => p.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();
        }

        private static void ConfigureValueObjects(EntityTypeBuilder<Position> builder)
        {
            ConfigurePositionName(builder);
            ConfigurePositionDescription(builder);
        }

        private static void ConfigurePositionName(EntityTypeBuilder<Position> builder)
        {
            builder.OwnsOne(p => p.Name, nb =>
            {
                nb.Property(n => n.Value)
                    .IsRequired()
                    .HasColumnName("name");
            });
        }

        private static void ConfigurePositionDescription(EntityTypeBuilder<Position> builder)
        {
            builder.OwnsOne(p => p.Description, db =>
            {
                db.Property(d => d.Value)
                    .HasColumnName("description");
            });
        }
    }
}