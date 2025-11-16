using DataFarm.Api.Domain.Purchase.Aggregates;
using DataFarm.Api.Domain.Shared;

namespace DataFarm.Api.DTOs;

public class UpdatePurchaseRequest
{
    public Fornecedor? Fornecedor { get; set; }
    
    public DateOnly DataCompra {  get; set; }
    
    public List<Insumo>? Itens { get; set; }
}