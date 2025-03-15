namespace IndividualsDirectory.Application.Exceptions;

public class PersonNotFoundException(string message) : Exception(message) { }