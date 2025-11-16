using System.ComponentModel.DataAnnotations;
using DataFarm.Api.Domain.Purchase.Aggregates;
using DataFarm.Api.Domain.Shared;

namespace DataFarm.Api.DTOs;

public class CreatePurchaseRequest
{
    [Required(ErrorMessage = "Informe o fornecedor")]
    public Fornecedor FornecedorId { get; set; }
    
    [Required(ErrorMessage = "Informe a data da compra")]
    public DateOnly DataCompra { get; set; }

    [Required(ErrorMessage = "A compra deve conter pelo menos um item")]
    public List<CreateInsumoRequest> Itens { get; set; } = [];

}