namespace IndividualsDirectory.Api.Models;

public class ValidationError
{
    public string Field { get; set; }
    public List<string> Messages { get; set; }
}