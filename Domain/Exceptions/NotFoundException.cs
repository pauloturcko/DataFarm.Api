namespace DataFarm.Api.Domain.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string entityName, int id) : base($"O {entityName} com ID {id} não foi encontrado.") { }
}