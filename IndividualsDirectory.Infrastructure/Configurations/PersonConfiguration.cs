using IndividualsDirectory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndividualsDirectory.Infrastructure.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.LastName)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.PersonalNumber)
            .IsRequired()
            .HasMaxLength(11)
            .IsUnicode(false);

        builder.Property(p => p.BirthDate)
            .IsRequired();

        builder.Property(p => p.ImagePath)
            .HasMaxLength(500);

        builder.HasOne(p => p.City)
            .WithMany()
            .HasForeignKey(p => p.CityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.ToTable(tb => tb.HasCheckConstraint("CHK_FirstName", "FirstName COLLATE Latin1_General_BIN NOT LIKE '%[ა-ჰ]%' OR FirstName COLLATE Georgian_Modern_Sort_BIN NOT LIKE '%[A-Za-z]%'"));
        builder.ToTable(tb => tb.HasCheckConstraint("CHK_LastName", "LastName COLLATE Latin1_General_BIN NOT LIKE '%[ა-ჰ]%' OR LastName COLLATE Georgian_Modern_Sort_BIN NOT LIKE '%[A-Za-z]%'"));
        builder.ToTable(tb => tb.HasCheckConstraint("CHK_PersonalNumber", "LEN(PersonalNumber) = 11 AND PersonalNumber NOT LIKE '%[^0-9]%'"));
        builder.ToTable(tb => tb.HasCheckConstraint("CHK_BirthDate", "DATEDIFF(year, BirthDate, GETDATE()) >= 18"));
    }
}