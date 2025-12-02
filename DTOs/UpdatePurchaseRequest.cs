using DataFarm.Api.Domain.Purchase.Aggregates;
using DataFarm.Api.Domain.Shared;

namespace DataFarm.Api.DTOs;

public class UpdatePurchaseRequest
{
    public int? FornecedorFk { get; set; }
    
    public DateOnly? DataCompra {  get; set; }
    
    public List<CreateInsumoRequest>? Itens { get; set; }
}