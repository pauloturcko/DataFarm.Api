using DataFarm.Api.Domain.Animais;
using DataFarm.Api.Domain.Config;
using DataFarm.Api.Domain.Stock;
using DataFarm.Api.Application.Repositories;
using DataFarm.Api.Domain.Exceptions;
using DataFarm.Api.Repositories;

namespace DataFarm.Api.Application.Services;

public class AnimalService : IAnimalService
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IFarmConfigRepository _farmConfigRepository;

    public AnimalService(IAnimalRepository animalRepository, IFarmConfigRepository farmConfigRepository)
    {
        _animalRepository = animalRepository;
        _farmConfigRepository = farmConfigRepository;
    }

    public async Task<Animal?> CreateAnimalAsync(Animal animal)
    {
        var farmConfig = await _farmConfigRepository.GetFarmConfigAsync();
        var currentAnimals = await _animalRepository.CountAllAsync();

        if ( currentAnimals >= farmConfig.MaxAnimalCapacity)
        {
            throw new AnimalsMaxCapacityReachedException(
                "Não foi possível realizar o cadastro. Capacidade máxima de animais atingida.");
            
        }
        _animalRepository.Add(animal);
        await _animalRepository.SaveChangesAsync(); 
        return animal;
     
    }

    public async Task<Animal?> GetAnimalByIdAsync(int id)
    {
        var animal = await _animalRepository.GetByIdAsync(id);

        if (animal == null)
        {
            throw new NotFoundException(
                "animal", id);
        }
        
        return animal;
    }

    public async Task<List<Animal>> GetAnimalListAsync()
    {
        var animals = await _animalRepository.GetAllAsync();

        if (animals.Count == 0)
        {
            throw new NotFoundAllException("Nenhum registro foi encontrado.");
        }
        
        return animals;
    }
    
}