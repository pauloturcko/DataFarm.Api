using DataFarm.Api.Domain.Shared.Enum;

namespace DataFarm.Api.DTOs;

public class UpdateItemRequest
{
    public string Nome { get; set; }
    
    public TipoInsumo Tipo { get; set; }
    
    public double Quantidade { get; set; }
}