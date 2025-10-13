using System.ComponentModel.DataAnnotations;

namespace DataFarm.Api.DTOs;

public class CreateAnimalRequest
{
    // [Required] é um Data Annotation que garante que o campo não seja nulo.
    [Required(ErrorMessage = "A raça do animal é obrigatória.")]
    public string Raca { get; set; } 

    // A data em que o animal chegou na fazenda.
    [Required(ErrorMessage = "A data de chegada é obrigatória.")]
    public DateOnly DataChegada { get; set; }

    // O peso inicial no momento do cadastro.
    [Required(ErrorMessage = "O peso inicial é obrigatório.")]
    [Range(0.1, 1000, ErrorMessage = "O peso deve ser um valor positivo.")]
    public double PesoInicial { get; set; } 
}