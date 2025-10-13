using System.ComponentModel.DataAnnotations;
using DataFarm.Api.Domain.Animais.Enum;

namespace DataFarm.Api.DTOs;

public class UpdateAnimalRequest
{
    [Required(ErrorMessage = "O ID do animal é obrigatório")]
    public int Id { get; set; }
    
    public DateOnly? DataChegada { get; set; }
    
    public RacaEnum? Raca { get; set; }
}