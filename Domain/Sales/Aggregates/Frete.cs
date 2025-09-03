namespace DataFarm.Api.Domain.Sales.Aggregates;

public class Frete
{
    public int QtdAnimais { get; set; }
    public decimal ValorPrimeiroComboio { get; set; }
    public decimal ValorSegundoComboio { get; set; }
    public string? Destino { get; set; }
    public Veiculo? Veiculo { get; set; }
    public decimal ValorTotal { get; set; }
}
