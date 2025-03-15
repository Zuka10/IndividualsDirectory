using IndividualsDirectory.Domain.Enums;

namespace IndividualsDirectory.Application.Person;

public class PhoneNumberDto
{
    public string PhoneNumber { get; set; } = null!;
    public PhoneNumberType NumberType { get; set; }
}