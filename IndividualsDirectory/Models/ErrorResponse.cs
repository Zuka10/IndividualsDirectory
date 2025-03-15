namespace IndividualsDirectory.Api.Models;

public class ErrorResponse
{
    public string Type { get; set; }
    public List<ValidationError> Errors { get; set; }
}