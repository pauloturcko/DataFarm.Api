using DataFarm.Api.Domain.Purchase.Aggregates;
using DataFarm.Api.Domain.Shared;

namespace DataFarm.Api.Domain.Purchase;

public class Compra
{
    public int Id { get; set; }
    public Fornecedor? Fornecedor { get; set; }
    public DateOnly DataCompra {  get; set; }
    public List<Insumo>? Itens { get; set; }
    public Decimal ValorTotal  { get; set; }
}
