using DataFarm.Api.Domain.Animais;

namespace DataFarm.Api.Application.Repositories;

public interface IAnimalRepository
{
    void Add(Animal animal);
    
    void Update(Animal animal);
    
    void Delete(Animal animal);
    
    Task<Animal?> GetByIdAsync(int id);
    
    Task<int> CountAllAsync(); // Não lembro por que criei esse método aqui
    
    Task<bool> SaveChangesAsync();
    
    Task<List<Animal>> GetAllAsync();
}