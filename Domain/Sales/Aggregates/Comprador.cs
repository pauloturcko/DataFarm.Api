namespace DataFarm.Api.Domain.Sales.Aggregates;

public class Comprador
{
    public int Id { get; set; }
    public string? EmpresaNome { get; set; }
    public string? Cnpj { get; set; }
    public string? Endereco { get; set; }
    public string? Email { get; set; }
    public string? Telefone { get; set; }

}
