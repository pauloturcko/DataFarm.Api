using System.ComponentModel.DataAnnotations;

namespace DataFarm.Api.DTOs;

public class RegisterWeightRequest
{
    // O ID do animal ao qual este peso pertence (Chave para a busca)
    [Required(ErrorMessage = "O ID do animal é obrigatório.")]
    public int AnimalId { get; set; }
    
    // O peso que está sendo registrado
    [Required(ErrorMessage = "O peso do animal é obrigatório.")]
    [Range(0.1, 9999.99, ErrorMessage = "O peso deve ser um valor positivo válido.")]
    public double PesoAnimal { get; set; }
}