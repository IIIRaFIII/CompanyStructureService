using CompanyStructureService.Domain.Locations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CompanyStructureService.Infrastructure.EFCore.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            ConfigureTable(builder);
            ConfigureProperties(builder);
            ConfigureValueObjects(builder);
        }

        private static void ConfigureTable(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable("locations");
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Id)
                .HasConversion(id => id.Value, value => LocationId.Create(value))
                .HasColumnName("id");
        }

        private static void ConfigureProperties(EntityTypeBuilder<Location> builder)
        {
            builder.Property(v => v.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();

            builder.Property(v => v.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();
        }

        private static void ConfigureValueObjects(EntityTypeBuilder<Location> builder)
        {
            ConfigureLocationName(builder);
            ConfigureLocationAddress(builder);
            ConfigureLocationTimezone(builder);
        }

        private static void ConfigureLocationName(EntityTypeBuilder<Location> builder)
        {
            builder.OwnsOne(v => v.Name, nb =>
            {
                nb.Property(v => v.Value)
                    .IsRequired()
                    .HasColumnName("name");
            });
        }

        private static void ConfigureLocationAddress(EntityTypeBuilder<Location> builder)
        {
            builder.OwnsOne(v => v.Address, nb =>
            {
                nb.Property(v => v.Country)
                    .IsRequired()
                    .HasColumnName("country");

                nb.Property(v => v.City)
                    .IsRequired()
                    .HasColumnName("city");

                nb.Property(v => v.Street)
                    .IsRequired()
                    .HasColumnName("street");

                nb.Property(v => v.PostalCode)
                    .IsRequired()
                    .HasColumnName("postal_code");
            });
        }

        private static void ConfigureLocationTimezone(EntityTypeBuilder<Location> builder)
        {
            builder.OwnsOne(v => v.Timezone, nb =>
            {
                nb.Property(v => v.TimeZoneInfo)
                    .HasConversion(
                        tz => tz.Id,
                        id => TimeZoneInfo.FindSystemTimeZoneById(id))
                    .HasColumnName("timezone");

                nb.Ignore(v => v.TimeZoneIANA);
            });
        }
    }
}