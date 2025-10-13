using DataFarm.Api.Domain.Animais;
using DataFarm.Api.DTOs;

namespace DataFarm.Api.Application.Services;

public interface IAnimalService
{
    // C
    Task<Animal?> CreateAnimalAsync(Animal animal);
    // R
    Task<Animal?> GetAnimalByIdAsync(int id);
    // R
    Task<List<Animal>> GetAnimalListAsync();
    // U
    Task<Animal?> UpdateAnimalAsync(UpdateAnimalRequest request);
    // D
    Task<bool> DeleteAnimalAsync(int id);
}