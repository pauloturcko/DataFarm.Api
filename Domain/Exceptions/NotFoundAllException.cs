namespace DataFarm.Api.Domain.Exceptions;

public class NotFoundAllException : Exception
{
    public NotFoundAllException(string message) : base(message) { }
    
}