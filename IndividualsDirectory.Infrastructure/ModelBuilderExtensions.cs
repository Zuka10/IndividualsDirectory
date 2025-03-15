using IndividualsDirectory.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IndividualsDirectory.Infrastructure;

public static class ModelBuilderExtensions
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>().HasData(
            new City { Id = 1, Name = "Tbilisi" },
            new City { Id = 2, Name = "London" },
            new City { Id = 3, Name = "Paris" },
            new City { Id = 4, Name = "Berlin" },
            new City { Id = 5, Name = "Tokyo" },
            new City { Id = 6, Name = "New York" }
        );

        modelBuilder.Entity<Person>().HasData(
            new Person { Id = 1, FirstName = "John", LastName = "Doe", PersonalNumber = "12345678910", BirthDate = new DateTime(1990, 1, 1, 0, 0, 0, DateTimeKind.Local), CityId = 1 },
            new Person { Id = 2, FirstName = "Jane", LastName = "Shpilman", PersonalNumber = "12345678911", BirthDate = new DateTime(1991, 1, 1, 0, 0, 0, DateTimeKind.Local), CityId = 2 },
            new Person { Id = 3, FirstName = "Jack", LastName = "Nicholson", PersonalNumber = "12345678912", BirthDate = new DateTime(1992, 1, 1, 0, 0, 0, DateTimeKind.Local), CityId = 3 },
            new Person { Id = 4, FirstName = "Jill", LastName = "James", PersonalNumber = "12345678913", BirthDate = new DateTime(1993, 1, 1, 0, 0, 0, DateTimeKind.Local), CityId = 4 },
            new Person { Id = 5, FirstName = "James", LastName = "Jackson", PersonalNumber = "12345678914", BirthDate = new DateTime(1994, 1, 1, 0, 0, 0, DateTimeKind.Local), CityId = 5 },
            new Person { Id = 6, FirstName = "Jenny", LastName = "Smith", PersonalNumber = "12345678915", BirthDate = new DateTime(1995, 1, 1, 0, 0, 0, DateTimeKind.Local), CityId = 6 }
        );

        modelBuilder.Entity<PhoneNumber>().HasData(
            new PhoneNumber { Id = 1, Number = "555-555-555", PersonId = 1 },
            new PhoneNumber { Id = 2, Number = "555-555-556", PersonId = 2 },
            new PhoneNumber { Id = 3, Number = "555-555-557", PersonId = 3 },
            new PhoneNumber { Id = 4, Number = "555-555-558", PersonId = 4 },
            new PhoneNumber { Id = 5, Number = "555-555-559", PersonId = 5 },
            new PhoneNumber { Id = 6, Number = "555-555-560", PersonId = 6 }
        );

        modelBuilder.Entity<RelatedIndividual>().HasData(
            new RelatedIndividual { Id = 1, Relationship = Domain.Enums.RelationshipType.Colleague, PersonId = 1, RelatedPersonId = 2 },
            new RelatedIndividual { Id = 2, Relationship = Domain.Enums.RelationshipType.Acquaintance, PersonId = 2, RelatedPersonId = 3 },
            new RelatedIndividual { Id = 3, Relationship = Domain.Enums.RelationshipType.Acquaintance, PersonId = 3, RelatedPersonId = 4 },
            new RelatedIndividual { Id = 4, Relationship = Domain.Enums.RelationshipType.Other, PersonId = 4, RelatedPersonId = 5 },
            new RelatedIndividual { Id = 5, Relationship = Domain.Enums.RelationshipType.Other, PersonId = 5, RelatedPersonId = 6 },
            new RelatedIndividual { Id = 6, Relationship = Domain.Enums.RelationshipType.Colleague, PersonId = 6, RelatedPersonId = 1 }
            );
    }
}