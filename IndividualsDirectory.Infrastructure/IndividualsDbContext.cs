using IndividualsDirectory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndividualsDirectory.Infrastructure;

public class IndividualsDbContext(DbContextOptions<IndividualsDbContext> options) : DbContext(options)
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<PhoneNumber> PhoneNumbers { get; set; }
    public DbSet<RelatedIndividual> RelatedIndividuals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IndividualsDbContext).Assembly);
    }
}