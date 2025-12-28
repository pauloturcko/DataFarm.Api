using System.ComponentModel.DataAnnotations;
using DataFarm.Api.Domain.Shared.Enum;

namespace DataFarm.Api.DTOs;

public class AddItemRequest
{
    [Required(ErrorMessage = "Informe o nome do item")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Informe o tipo do item")]
    public TipoInsumo Tipo { get; set; }
    
    [Required(ErrorMessage = "Informe a quantidade do item")]
    public double Quantidade { get; set; }
}