using DataFarm.Api.Domain.Sales.Aggregates;

namespace DataFarm.Api.Domain.Sales;

public class Venda
{
    public int Id { get; set; }
    public int QtdeAnimais { get; set; }
    public Frete? Frete { get; set; }
    public Comprador? Comprador { get; set; }
    public decimal ValorDeVenda { get; set; }
    public decimal LucroTotal { get; set; }
}
