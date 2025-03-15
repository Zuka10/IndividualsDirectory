using IndividualsDirectory.Domain.Enums;

namespace IndividualsDirectory.Application.Person;

public class PersonDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public GenderType Gender { get; set; }
    public string PersonalNumber { get; set; } = null!;
    public DateTime BirthDate { get; set; }
    public int CityId { get; set; }
    public string? ImagePath { get; set; }

    public string CityName { get; set; } = null!;
    public List<string> PhoneNumbers { get; set; } = [];
    public List<string> RelatedIndividuals { get; set; } = [];
}