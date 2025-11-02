using DataFarm.Api.Domain.Animais;
using DataFarm.Api.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataFarm.Api.Infra.Data; 

// A classe concreta implementa o contrato (a interface)
public class AnimalRepository : IAnimalRepository 
{
    // 1. Campo privado, garantimos que NUNCA será nulo
    private readonly AppDbContext _context; 
    
    // Construtor com Injeção de Dependência (DI)
    public AnimalRepository(AppDbContext context)
    {
        _context = context;
    }

    // C - Adiciona a intenção de salvar no Contexto (Memória)
    public void Add(Animal animal)
    {
        _context.Animals.Add(animal); 
    }
    
    // R - Busca o Animal no banco de forma assíncrona
    public async Task<Animal?> GetByIdAsync(int id)
    {
        // O FindAsync é o método mais rápido do EF Core para buscar pela PK
        return await _context.Animals.FindAsync(id);
    }
    
    // U - Marca o Animal como modificado (operação rastreada pelo EF Core)
    public void Update(Animal animal)
    {
        _context.Animals.Update(animal);
    }
    
    // D - Marca o Animal para ser removido do banco de dados
    public void Delete(Animal animal)
    {
        _context.Animals.Remove(animal);
    }

    public async Task<int> CountAllAsync()
    {
      return await _context.Animals.CountAsync();
    }
    
    public async Task<List<Animal>> GetAllAsync()
    {
        return await _context.Animals.ToListAsync();
    }

    // Finaliza a transação: gera o SQL e envia para o PostgreSQL
    public async Task<bool> SaveChangesAsync()
    {
        // Retorna true se pelo menos uma linha foi alterada (> 0)
        return await _context.SaveChangesAsync() > 0;
    }


}