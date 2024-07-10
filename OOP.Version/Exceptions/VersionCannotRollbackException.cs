namespace OOP.Version.Exceptions;

public class VersionCannotRollbackException : Exception
{
    public VersionCannotRollbackException() : base("Cannot rollback!") { }
}
