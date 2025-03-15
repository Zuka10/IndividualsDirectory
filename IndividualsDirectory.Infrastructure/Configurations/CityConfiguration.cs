using IndividualsDirectory.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndividualsDirectory.Infrastructure.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.ToTable(tb => tb.HasCheckConstraint("CHK_CityName", "Name COLLATE Latin1_General_BIN NOT LIKE '%[ა-ჰ]%' OR Name COLLATE Georgian_Modern_Sort_BIN NOT LIKE '%[A-Za-z]%'"));
    }
}