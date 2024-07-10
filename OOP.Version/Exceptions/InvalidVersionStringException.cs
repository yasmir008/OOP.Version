namespace OOP.Version.Exceptions;

public class InvalidVersionStringException : Exception
{
    public InvalidVersionStringException() : base("Error occured while parsing version!") { }
}
