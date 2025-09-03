namespace DataFarm.Api.Domain.Sales.Aggregates;

public class Veiculo
{
    public string? Marca { get; set; }
    public string? Modelo { get; set; }
    public int Eixos { get; set; }
    public string? Placa { get; set; }
    public string? Motorista { get; set; }
    public int MaxAnimaisPorComboio { get; set; }
    public int ComboiosMaximos { get; set; }
    public decimal ValorFrete { get; set; }
}
