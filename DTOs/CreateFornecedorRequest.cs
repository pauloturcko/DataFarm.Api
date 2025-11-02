using System.ComponentModel.DataAnnotations;
using DataFarm.Api.Domain.Purchase.Enum;

namespace DataFarm.Api.DTOs;

public class CreateFornecedorRequest
{
    [Required(ErrorMessage = "Informe o nome do fornecedor.")]
    public string? Nome { get; set; }
    
    [Required(ErrorMessage = "Informe o tipo do fornecedor.")]
    public TipoFornecedor Tipo  { get; set; }
    
    public bool Favorito { get; set; }
}