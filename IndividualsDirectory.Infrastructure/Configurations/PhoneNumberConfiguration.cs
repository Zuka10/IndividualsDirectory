using IndividualsDirectory.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndividualsDirectory.Infrastructure.Configurations;

public class PhoneNumberConfiguration : IEntityTypeConfiguration<PhoneNumber>
{
    public void Configure(EntityTypeBuilder<PhoneNumber> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Number)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(p => p.Person)
            .WithMany(p => p.PhoneNumbers)
            .HasForeignKey(p => p.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.ToTable(tb => tb.HasCheckConstraint("CHK_PhoneNumber", "LEN(Number) BETWEEN 4 AND 50"));
    }
}