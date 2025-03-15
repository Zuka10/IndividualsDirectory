using IndividualsDirectory.Domain.Enums;

namespace IndividualsDirectory.Domain.Entities;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public GenderType Gender { get; set; }
    public string PersonalNumber { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public int CityId { get; set; }
    public string? ImagePath { get; set; }

    public virtual City? City { get; set; }
    public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; } = [];
    public virtual ICollection<RelatedIndividual> RelatedIndividuals { get; set; } = [];
}