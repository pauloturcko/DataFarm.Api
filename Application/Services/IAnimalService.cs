using DataFarm.Api.Domain.Animais;

namespace DataFarm.Api.Application.Services;

public interface IAnimalService
{
    Task<Animal?> CreateAnimalAsync(Animal animal);
}