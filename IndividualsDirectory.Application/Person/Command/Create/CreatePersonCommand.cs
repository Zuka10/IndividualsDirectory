using IndividualsDirectory.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IndividualsDirectory.Application.Person.Command.Create;

public class CreatePersonCommand : IRequest<int>
{
    [MinLength(2), MaxLength(50)]
    [Required]
    public string FirstName { get; set; } = null!;

    [MinLength(2), MaxLength(50)]
    [Required]
    public string LastName { get; set; } = null!;

    public GenderType Gender { get; set; }

    [RegularExpression(@"^\d{11}$")]
    [Required]
    public string PersonalNumber { get; set; } = null!;

    [Required]
    public DateTime BirthDate { get; set; }

    public int CityId { get; set; }

    public List<PhoneNumberDto> PhoneNumbers { get; set; } = [];
    public List<RelatedPersonDto> RelatedIndividuals { get; set; } = [];
}