using DataFarm.Api.Domain.Purchase.Enum;
using System.ComponentModel.DataAnnotations;
using DataFarm.Api.Domain.Shared.Enum;

namespace DataFarm.Api.DTOs;

public class CreateInsumoRequest
{
    [Required(ErrorMessage = "O nome do insumo é obrigatório.")]
    public string? Nome { get; set; }
    
    [Required(ErrorMessage = "O tipo do insumo é obrigatório.")]
    public TipoInsumo Tipo { get; set; }
    
    [Required(ErrorMessage = "A quantidade comprada é obrigatória.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "A quantidade deve ser positiva.")]
    public double Quantidade { get; set; }
    
    [Required(ErrorMessage = "O preço unitário é obrigatório.")]
    [Range(0.01, 999999.99, ErrorMessage = "O preço deve ser positivo.")]
    public decimal PrecoUnitario { get; set; }
}