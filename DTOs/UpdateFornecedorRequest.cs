using System.ComponentModel.DataAnnotations;
using DataFarm.Api.Domain.Purchase.Enum;

namespace DataFarm.Api.DTOs;

public class UpdateFornecedorRequest
{
    [Required(ErrorMessage = "Informe o id do fornecedor que deseja alterar")]
    public int Id { get; set; }
    
    public string? Nome { get; set; }
    
    public TipoFornecedor? Tipo { get; set; }
    
    public bool? Favorito { get; set; }
}