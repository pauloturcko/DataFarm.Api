namespace DataFarm.Api.Domain.Exceptions;

public class AnimalsMaxCapacityReachedException : Exception
{
    public AnimalsMaxCapacityReachedException(string message) : base(message) { }
}