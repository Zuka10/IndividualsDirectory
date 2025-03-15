using IndividualsDirectory.Domain.Enums;

namespace IndividualsDirectory.Domain;

public class PhoneNumber
{
    public int Id { get; set; }
    public PhoneNumberType NumberType { get; set; }
    public string Number { get; set; } = null!;
    public int PersonId { get; set; }

    public virtual Person? Person { get; set; }
}