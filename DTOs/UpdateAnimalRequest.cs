using System.ComponentModel.DataAnnotations;
using DataFarm.Api.Domain.Animais.Enum;

namespace DataFarm.Api.DTOs;

public class UpdateAnimalRequest
{
    public DateOnly? DataChegada { get; set; }
    
    public RacaEnum? Raca { get; set; }
}