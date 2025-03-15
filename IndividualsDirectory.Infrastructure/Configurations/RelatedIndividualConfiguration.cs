using IndividualsDirectory.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IndividualsDirectory.Infrastructure.Configurations;

public class RelatedIndividualConfiguration : IEntityTypeConfiguration<RelatedIndividual>
{
    public void Configure(EntityTypeBuilder<RelatedIndividual> builder)
    {
        builder.HasKey(ri => ri.Id);

        builder.HasOne(ri => ri.Person)
            .WithMany(p => p.RelatedIndividuals)
            .HasForeignKey(ri => ri.PersonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ri => ri.RelatedPerson)
            .WithMany()
            .HasForeignKey(ri => ri.RelatedPersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}