using DataFarm.Api.Domain.Animais;
using DataFarm.Api.Domain.Config;
using DataFarm.Api.Domain.Stock;
using DataFarm.Api.Application.Repositories;
using DataFarm.Api.Domain.Animais.Aggregates;
using DataFarm.Api.Domain.Exceptions;
using DataFarm.Api.DTOs;
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

    public async Task<bool> DeleteAnimalAsync(int id)
    {
        var animal = await _animalRepository.GetByIdAsync(id);

        if (animal == null)
        {
            throw new NotFoundException("Animal", id);
        }
        
        _animalRepository.Delete(animal);

        return await _animalRepository.SaveChangesAsync();
    }

    public async Task<Animal?> UpdateAnimalAsync(int id, UpdateAnimalRequest request)
    {
        var animal = await _animalRepository.GetByIdAsync(id);

        if (animal == null)
        {
            throw new NotFoundException("Animal", id);
        }

        if (request.DataChegada.HasValue)
        {
            animal.DataChegada = request.DataChegada.Value;
        }

        if (request.Raca.HasValue)
        {
            animal.Raca = request.Raca.Value;
        }
        
        _animalRepository.Update(animal);

        return await _animalRepository.SaveChangesAsync() ? animal : null;
    }

    public async Task<Animal?> RegisterWeightAsync(RegisterWeightRequest request)
    {
        var animal = await _animalRepository.GetByIdAsync(request.AnimalId);
        
        if(animal == null)
        {
            throw new NotFoundException("Animal", request.AnimalId);
        }

        var novoRegistroPeso = new Peso
        {
            PesoAnimal = request.PesoAnimal,
            DataRegistro = DateOnly.FromDateTime(DateTime.Now),
        };
        
        animal.HistoricoPeso.Add(novoRegistroPeso);
        
        _animalRepository.Update(animal);
        
        return await _animalRepository.SaveChangesAsync() ? animal : null;
    }
    
}